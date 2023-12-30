using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//string localIP = LocalIPAddress();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
builder.Services.AddCors(options =>
{

    options.AddPolicy(name:"Policy1",
       builder =>
        {
           /*policy.WithOrigins("http://127.0.0.1:5066/",
                              "http://127.0.0.1:5066/")
                                .AllowAnyHeader()
                               .AllowAnyMethod();*/
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                .AllowAnyHeader().AllowAnyMethod();

        });

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
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder => builder
         .SetIsOriginAllowedToAllowWildcardSubdomains()
         .WithOrigins("http://192.168.151.215:4200/", "http://*.")
         .AllowAnyMethod()
         .AllowCredentials()
         .AllowAnyHeader()
         .Build()
      );

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache(); 

var app = builder.Build();
//app.Urls.Add("http://" + localIP + ":5072");
//app.Urls.Add("https://" + localIP + ":7072");
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
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Uploads"
});
    /*app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
       // RequestPath = new PathString("/Uploads")
    });*/
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + ex.StackTrace);
}
#endregion
app.UseHttpsRedirection();


/*app.UseCors(MyAllowSpecificOrigins);*/
app.UseCors();
//app.Use((corsContext, next) =>
//{
//corsContext.Response.Headers["Access-Control-Allow-Origin"] = "*";
//return next.Invoke();
//});
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();
//app.UseSession();
app.Run();

/*static string LocalIPAddress()
{
    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
    {
        socket.Connect("192.168.0.160",7066);
        IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;
        if (endPoint != null)
        {
            return endPoint.Address.ToString();
        }
        else
        {
            return "127.0.0.1";
        }
    }
}*/
