using AutoMapper;
using AutoMapper.EquivalencyExpression;
using JobApi.Models.DTOS.CompanyDTOS;
using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.DTOS.SeekerDTOS;
using JobApi.Models.DTOS.UserAccountDTOS;
using JobApi.Models.JobPostModels;
using JobApi.Models.UserAccountModels;
using Microsoft.Build.Framework;

namespace JobApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobPost, JobPostDTO>();
            CreateMap<JobPostDTO, JobPost>().ForMember(dest => dest.JobSkills, opt => opt.MapFrom(src => src.JobSkill));
            CreateMap<JobLocation, JobLocationDTO>();
            CreateMap<JobLocationDTO, JobLocation>();
            CreateMap<JobPost, JobPostGetDTO>();
            CreateMap<JobPostGetDTO, JobPost>();
            CreateMap<JobCategory, JobCategoryDTO>();
            CreateMap<JobCategoryDTO, JobCategory>();
            CreateMap<JobCategoryPostDTO, JobCategory>();
            CreateMap<JobCategory, JobCategoryPostDTO>();

            CreateMap<JobSkill, JobSkillDTO>().ForMember(dest => dest.JobSkillId, opt => opt.MapFrom(src => src.JobSkillId));
            CreateMap<JobSkillDTO, JobSkill>().ForMember(dest => dest.JobSkillId, opt => opt.MapFrom(src => src.JobSkillId));

            //CreateMap<JobSkill, JobSkillDTO>();
            ///CreateMap<JobSkillDTO, JobSkill>();
            CreateMap<Company, CompanyPostDTO>();
            CreateMap<CompanyPostDTO, Company>();
            CreateMap<Company, CompanyGetDTO>();
            CreateMap<CompanyGetDTO, Company>();
            CreateMap<CompanyForJobPostDTO, Company>();
            CreateMap<Company, CompanyForJobPostDTO>();

            CreateMap<SeekerProfilePostDTO, SeekerProfile>().ForMember(dest => dest.SeekerSkills, opt => opt.MapFrom(src => src.SeekerSkills)); 
            CreateMap<SeekerProfile, SeekerProfilePostDTO>().ForMember(dest => dest.SeekerSkills, opt => opt.MapFrom(src => src.SeekerSkills));
            CreateMap<SeekerProfileGetDTO, SeekerProfile>();
            CreateMap<SeekerProfile, SeekerProfileGetDTO>();

            CreateMap<SeekerProfilePutDTO, SeekerProfile>();
            CreateMap<SeekerProfile, SeekerProfilePutDTO>();

            CreateMap<SeekerSkillDTO, SeekerSkill>();
            CreateMap<SeekerSkill, SeekerSkillDTO>();
            CreateMap<SeekerSkillPutDTO, SeekerSkill>();
            CreateMap<SeekerSkill, SeekerSkillPutDTO>();

            CreateMap<SeekerEducationDetailDTO, SeekerEducationDetail>();
            CreateMap<SeekerEducationDetail, SeekerEducationDetailDTO>();

            CreateMap<SeekerExperienceDetailDTO, SeekerExperienceDetail>();
            CreateMap<SeekerExperienceDetail, SeekerExperienceDetailDTO>();

            CreateMap<UserAccount, UserAccountDTO>();
            CreateMap<UserAccountDTO, UserAccount>();
            CreateMap<UserType, UserTypeDTO>();
            CreateMap<UserTypeDTO, UserType>();
        }
    }
}
