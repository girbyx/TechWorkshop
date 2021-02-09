using System;
using System.Collections.Generic;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class PiecePurchaseOrder : IIdentityFields, IAuditFields
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
        public virtual Recipient Recipient { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
    }

    public class PiecePurchaseOrderProfile : Profile
    {
        public PiecePurchaseOrderProfile()
        {
            CreateMap<PiecePurchaseOrder, PiecePurchaseOrderViewModel>();
            CreateMap<PiecePurchaseOrderViewModel, PiecePurchaseOrder>();
        }
    }
}