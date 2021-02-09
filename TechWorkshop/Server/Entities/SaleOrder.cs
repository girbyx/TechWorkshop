using System;
using System.Collections.Generic;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class SaleOrder : IIdentityFields, IAuditFields
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
        public virtual Recipient Recipient { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
    }

    public class SaleOrderProfile : Profile
    {
        public SaleOrderProfile()
        {
            CreateMap<SaleOrder, SaleOrderViewModel>();
            CreateMap<SaleOrderViewModel, SaleOrder>();
        }
    }
}