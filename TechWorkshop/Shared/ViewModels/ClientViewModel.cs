using System;
using System.Collections.Generic;
using TechWorkshop.Shared.Interfaces;

namespace TechWorkshop.Shared.ViewModels
{
    public class ClientViewModel : ISelectableViewModel
    {
        public Guid Id { get; set; }
        public string Suffix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name => string.Join(" ", Suffix, FirstName, MiddleName, LastName);
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressCont { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public string Comments { get; set; }

        // audit
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public IList<SaleOrderViewModel> SaleOrders { get; set; }
        public IList<RepairOrderViewModel> RepairOrders { get; set; }
    }
}