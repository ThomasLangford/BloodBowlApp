using BloodBowlAPI.DTOs.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Validators
{
    public class UniqueSkillDtoCollectionValidator : ValidationAttribute
    {
        public bool IsValidObj(object obj)
        {
            var skills = (IEnumerable<SkillDto>)obj;

            var diffChecker = new HashSet<int>();

            return skills.All(skill => diffChecker.Add(skill.Id));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IsValidObj(value))
            {
                return new ValidationResult("A Skill is listed more than once.");
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
