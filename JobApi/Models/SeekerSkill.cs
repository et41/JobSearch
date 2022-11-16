﻿using JobApi.Models.JobPostModels;

namespace JobApi.Models
{
    public class SeekerSkill
    {
        public int SeekerSkillId { get; set; }
        public int? JobSkillId { get; set; }
        public JobSkill? JobSkill { get; set; }
        public ICollection<SeekerProfile>? seekerProfiles { get; set; }
    }
}
