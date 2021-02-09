using System;

namespace TechWorkshop.Shared.Interfaces
{
    public interface  ISelectableViewModel
    {
        Guid Id { get; set; }
        string Name { get; }
    }
}
