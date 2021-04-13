namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillDto : SkillDtoSimple
    {
        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public string SkillCategoryShortName { get; set; }

        public int RuleSetId { get; set; }
        public string RulesetName { get; set; }
    }
}
