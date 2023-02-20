using System.Collections.Generic;
using VideoRentalStore.Models;

namespace VideoRentalStore.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                if (Customer.Id == 0)
                {
                    return "New Customer";
                }
                return "Edit Customer";
            }

        }
    }
}