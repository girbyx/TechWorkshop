using System;
using System.Collections.Generic;
using TechWorkshop.Shared.Interfaces;

namespace TechWorkshop.Shared.ViewModels
{
    public class PiecePurchaseOrderViewModel : ISelectableViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Observations { get; set; }
        public string PaymentMethod { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Comments { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public Guid RecipientId { get; set; }
        public string RecipientName { get; set; }
        public IList<PieceViewModel> Pieces { get; set; }
    }
}