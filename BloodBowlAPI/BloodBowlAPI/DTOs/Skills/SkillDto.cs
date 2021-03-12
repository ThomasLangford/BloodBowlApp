namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string InternalName { get; set; }
        public string LocalisationName { get; set; }
        public string LocalisationDescription { get; set; }

        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public char SkillCategoryShortName { get; set; }

        public int RuleSetId { get; set; }
        public string RuleSetName { get; set; }
    }
}
