using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechWorkshop.Server.Entities.Interfaces
{
    public interface IIdentityFields
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Id { get; set; }
    }
}
