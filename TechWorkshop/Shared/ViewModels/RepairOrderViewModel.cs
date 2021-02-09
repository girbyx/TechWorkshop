using System;

namespace TechWorkshop.Shared.ViewModels
{
    public class RepairOrderViewModel
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public long SerialNumber { get; set; }
        public string Observations { get; set; }
        public string Solution { get; set; }
        public double ApproximatePayment { get; set; }
        public double Payment { get; set; }
        public string PaymentMethod { get; set; }
        public DateTimeOffset? GuaranteeExpiration { get; set; }
        public string Comments { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public Guid RecipientId { get; set; }
        public string RecipientName { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
    }
}