using System;
using System.Collections.Generic;
using TechWorkshop.Shared.Interfaces;

namespace TechWorkshop.Shared.ViewModels
{
    public class PieceTypeViewModel : ISelectableViewModel
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
        public virtual IList<PieceViewModel> Pieces { get; set; }
    }
}