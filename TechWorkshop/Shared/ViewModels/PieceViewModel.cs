using System;
using TechWorkshop.Shared.Interfaces;

namespace TechWorkshop.Shared.ViewModels
{
    public class PieceViewModel : ISelectableViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public long SerialNumber { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public virtual Guid PieceTypeId { get; set; }
        public virtual string PieceTypeName { get; set; }
        public virtual Guid PiecePurchaseOrderId { get; set; }
        public virtual string PiecePurchaseOrderName { get; set; }
        public virtual Guid? SaleOrderId { get; set; }
        public virtual string SaleOrderName { get; set; }
    }
}