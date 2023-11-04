using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<ExamPortalSettings>().BindConfiguration("ExamPortalSettings");
builder.Services.AddDbContext<ExamPortalDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ExamPortalDatabaseContext>();
builder.Services.AddCustomServices();
builder.Services.AddMapper();
builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var key = builder.Configuration["ExamPortalSettings:Key"];
    var issuer = builder.Configuration["ExamPortalSettings:Issuer"];
    var audience = builder.Configuration["ExamPortalSettings:Issuer"];

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
builder.Services.AddControllers();
/*builder.Services.AddControllers().

    // Use the default property (Pascal) casing

    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

});*/
/*builder.Services.AddCors(options =>
{
    //options.AddPolicy("Policy1",
    //    policy =>
    //    {
    //        policy.WithOrigins("http://154.0.166.61",
    //                            "http://154.0.166.61")
    //                            .AllowAnyHeader()
    //                            .AllowAnyMethod();
    //    });

    //options.AddPolicy("AnotherPolicy",
    //    policy =>
    //    {
    //        policy.WithOrigins("http://localhost", "https://localhost")
    //                            .AllowAnyHeader()
    //                            .AllowAnyMethod();
    //    });

    options.AddPolicy("MyCorsPolicy",
       builder => builder
          .SetIsOriginAllowedToAllowWildcardSubdomains()
          .WithOrigins("https://*.", "http://*.")
          .AllowAnyMethod()
          .AllowCredentials()
          .AllowAnyHeader()
          .Build()
       );
});*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache(); 

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
    app.UseSwaggerUI();
#region Use Static Files
try
{
    app.UseStaticFiles();
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
        RequestPath = new PathString("/Uploads")
    });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + ex.StackTrace);
}
#endregion
app.UseHttpsRedirection();
app.UseCors();
/*app.Use((corsContext, next) =>
{
    corsContext.Response.Headers["Access-Control-Allow-Origin"] = "*";
    return next.Invoke();
});*/
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();
//app.UseSession();
app.Run();
