using System;
using System.Collections.Generic;
using AutoMapper;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Entities
{
    public class PieceType : IIdentityFields, IAuditFields
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // relations
        public virtual ICollection<Piece> Pieces { get; set; }
    }

    public class PieceTypeProfile : Profile
    {
        public PieceTypeProfile()
        {
            CreateMap<PieceType, PieceTypeViewModel>();
            CreateMap<PieceTypeViewModel, PieceType>();
        }
    }
}