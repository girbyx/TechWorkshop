using System;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class Piece : IIdentityFields, IAuditFields
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
        public Guid PieceTypeId { get; set; }
        public virtual PieceType PieceType { get; set; }
        public Guid PiecePurchaseOrderId { get; set; }
        public virtual PiecePurchaseOrder PiecePurchaseOrder { get; set; }
        public Guid? SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
    }

    public class PieceProfile : Profile
    {
        public PieceProfile()
        {
            CreateMap<Piece, PieceViewModel>();
            CreateMap<PieceViewModel, Piece>();
        }
    }
}