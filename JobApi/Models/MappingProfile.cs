using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace JobApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobPost, JobPostDTO>();
            CreateMap<JobPostDTO, JobPost>();
            CreateMap<JobLocation, JobLocationDTO>();
            CreateMap<JobLocationDTO, JobLocation>();
            CreateMap<JobPost, JobPostGetDTO>();
            CreateMap<JobPostGetDTO, JobPost>();
            CreateMap<JobCategory, JobCategoryDTO>();
            CreateMap<JobCategoryDTO, JobCategory>();
            CreateMap<JobCategoryPostDTO, JobCategory>();
            CreateMap<JobCategory, JobCategoryPostDTO>();
        }
    }
}
