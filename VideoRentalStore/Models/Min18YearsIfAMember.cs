using System;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalStore.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            // customer.MembershipTypeId != 1 && customer.MembershipTypeId != 0
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate field is required.");
            }
            if (GetAge(customer.Birthdate) < 18)
            {
                return new ValidationResult("Customer should be at least 18 years old to go on a membership.");
            }
            return ValidationResult.Success;
        }
        public static int GetAge(DateTime? birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Value.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
