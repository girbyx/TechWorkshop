using System;
using System.Collections.Generic;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class Recipient : IIdentityFields, IAuditFields
    {
        public Guid Id { get; set; }
        public string Suffix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<PiecePurchaseOrder> PiecePurchaseOrders { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
    }

    public class RecipientProfile : Profile
    {
        public RecipientProfile()
        {
            CreateMap<Recipient, RecipientViewModel>();
            CreateMap<RecipientViewModel, Recipient>();
        }
    }
}