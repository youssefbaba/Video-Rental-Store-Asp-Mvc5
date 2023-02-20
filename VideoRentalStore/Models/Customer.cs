using System;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter customer's name.")]  // Custome Message Validation
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date Of Birth")]
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}