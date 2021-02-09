using System;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class Attachment : IIdentityFields, IAuditFields
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ExtensionType { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public Guid PiecePurchaseOrderId { get; set; }
        public virtual PiecePurchaseOrder PiecePurchaseOrder { get; set; }
        public Guid SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
        public Guid RepairOrderId { get; set; }
        public virtual RepairOrder RepairOrder { get; set; }
    }

    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentViewModel>();
            CreateMap<AttachmentViewModel, Attachment>();
        }
    }
}