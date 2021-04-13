namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public string SkillCategoryShortName { get; set; }

        public int RuleSetId { get; set; }
        public string RulesetName { get; set; }
    }
}
