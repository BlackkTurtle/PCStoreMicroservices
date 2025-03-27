using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? FatherName { get; set; }
        public int DeliverAddressId { get; set; }
        public int PaymentTypeId { get; set; }
        public int NakladnaId { get; set; }
        public int StatusId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }
        public DeliverAddress DeliverAddress { get; set; } = null!;
        public Nakladni Nakladna { get; set; } = null!;
        public PaymentType PaymentType { get; set; } = null!;
        public Status Status { get; set; } = null!;

    }
}
