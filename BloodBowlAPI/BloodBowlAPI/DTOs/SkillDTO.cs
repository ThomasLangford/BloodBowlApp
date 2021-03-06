namespace BloodBowlAPI.DTOs
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public char SkillCategoryShortName { get; set; }
    }
}
