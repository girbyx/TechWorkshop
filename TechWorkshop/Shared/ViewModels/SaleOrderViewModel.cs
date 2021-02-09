using System;
using System.Collections.Generic;

namespace TechWorkshop.Shared.ViewModels
{
    public class SaleOrderViewModel
    {
        public Guid Id { get; set; }
        public string Observations { get; set; }
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
        public IList<PieceViewModel> Pieces { get; set; }
    }
}