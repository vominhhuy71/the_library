using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.Models
{
    public class Min18YearsIfTeacher : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId != MembershipType.Teacher)
            {
                return ValidationResult.Success;
            };

            if(customer.Birthday == null)
            {
                return new ValidationResult("Birthday is required!");
            }
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Teacher should be at least 18 years old!");
        }
    }
}