using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Client.Pages.Client
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ClientViewModel> OriginalRecords;
        public IEnumerable<ClientViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.Name.ToLower().Contains(searchValue)
                || x.Email.ToLower().Contains(searchValue)
                || x.Address.ToLower().Contains(searchValue));
        }

        protected override async Task OnInitializedAsync()
        {
            Records = OriginalRecords = await Service.GetList();
        }

        protected async Task OnDeleteClick(Guid id)
        {
            await Service.Delete(id);
            OriginalRecords = OriginalRecords.Where(x => x.Id != id);
            Records = Records.Where(x => x.Id != id);
        }
    }
}