using BloodBowlAPI.DTOs.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Validators
{
    public class UniqueAvailableSkillCategoryCollectionValidator : ValidationAttribute
    {
        public bool IsValidObj(object obj)
        {
            var availableSkillCategories = (IEnumerable<AvailableSkillCategoryDto>)obj;

            var diffChecker = new HashSet<int>();

            return availableSkillCategories.All(availableSkillCategory => diffChecker.Add(availableSkillCategory.SkillCategoryId));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IsValidObj(value))
            {
                return new ValidationResult($"A Skill Category is listed more than once.");
            }

            return ValidationResult.Success;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
