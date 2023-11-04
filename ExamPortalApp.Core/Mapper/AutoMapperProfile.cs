using AutoMapper;
using ExamPortalApp.Contracts.Data.Dtos;
using ExamPortalApp.Contracts.Data.Entities;

namespace ExamPortalApp.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Center, CenterDto>()
                .ForMember(dest => dest.LicenceInfo, opt => opt.MapFrom(src => $"{src.Students.Count}/{src.MaximumLicense ?? 0}"));
            CreateMap<CenterDto, Center>();
            CreateMap<CenterType, CenterTypeDto>().ReverseMap();
            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<InvigilatorStudentLink, InvigilatorStudentLinkDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<RandomOtp, RandomOtpDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();          
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<TestCategory, TestCategoryDto>().ReverseMap();
            CreateMap<TestSecurityLevel, TestSecurityLevelDto>().ReverseMap();
            CreateMap<TestType, TestTypeDto>().ReverseMap();
            CreateMap<UploadedAnswerDocument, UploadedAnswerDocumentDto>().ReverseMap();
            CreateMap<UploadedSourceDocument, UploadedSourceDocumentDto>().ReverseMap();
            CreateMap<UploadedTest, UploadedTestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<StudentTest, StudentTestDTO>().ReverseMap();
        }
    }
}
