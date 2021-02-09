using System;
using System.Collections.Generic;
using TechWorkshop.Shared.Interfaces;

namespace TechWorkshop.Shared.ViewModels
{
    public class OrderViewModel : ISelectableViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public long SerialNumber { get; set; }
        public string Observations { get; set; }
        public string Recipient { get; set; }
        public string Solution { get; set; }
        public double ApproximatePayment { get; set; }
        public double Payment { get; set; }
        public string Comments { get; set; }
        public string PaymentMethod { get; set; }
        public DateTimeOffset? GuaranteeExpiration { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }

        // collections
        public virtual IList<PieceViewModel> Pieces { get; set; }
    }
}