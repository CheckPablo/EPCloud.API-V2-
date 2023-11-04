using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Core.Mapper;
using ExamPortalApp.Daemon.BackgroundWorkers;
using ExamPortalApp.Infrastructure.Data.Repositories;
using ExamPortalApp.Infrastructure.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Data.Repositories.Generics;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<ICenterTypeRespository, CenterTypeRespository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IInvigilatorStudentLinkRepository, InvigilatorStudentLinkRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITestCategoryRepository, TestCategoryRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestSecurityLevelRepository, TestSecurityLevelRepository>();
            services.AddScoped<ITestTypeRepository, TestTypeRepository>();
            services.AddScoped<IUserManagementRepository, UserManagementRepository>();
            services.AddScoped<IAttendanceRegisterRepository, AttendanceRegisterRepository>();
            services.AddScoped<ILiveMonitoringRepository, LiveMonitoringRepository>();
            services.AddScoped<ICenterAttendanceRepository, CenterAttendanceRepository>();
            services.AddScoped<IStudentTestRepository, StudentTestRepository>();
            services.AddScoped<IInTestWriteRepository, InTestWriteRepository>();

            services.AddHostedService<EmailSenderBackgroundWorker>();
            services.AddSingleton<IBackgroundQueue<EmailDto>, BackgroundQueue<EmailDto>>();

            services.AddHostedService<SendStudentCredentialsBackgroundWorker>();
            services.AddSingleton<IBackgroundQueue<Dictionary<int, int[]>>, BackgroundQueue<Dictionary<int, int[]>>>();

            services.AddHostedService<CreateStudentCredentialsBackgroundWorker>();
            services.AddSingleton<IBackgroundQueue<Tuple<int, int[]>>, BackgroundQueue<Tuple<int, int[]>>>();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            #region AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            return services;
        }
    }
}
