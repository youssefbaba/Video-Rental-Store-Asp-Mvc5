using System.Collections.Generic;

namespace VideoRentalStore.Models.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}