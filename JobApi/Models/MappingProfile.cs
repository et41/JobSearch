﻿using AutoMapper;
using AutoMapper.EquivalencyExpression;
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
            CreateMap<JobSkill, JobSkillDTO>();
            CreateMap<JobSkillDTO, JobSkill>();
        }
    }
}
