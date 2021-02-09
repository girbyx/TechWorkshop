using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Client.Pages.Client
{
    public class EditBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public ClientViewModel Record { get; set; } = new ClientViewModel();

        protected override async Task OnInitializedAsync()
        {
            var id = new Guid(Id);
            Record = await Service.Get(id);
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Update(Record);
            await Service.Return();
        }

        protected async Task OnDeleteClick(MouseEventArgs e)
        {
            var id = new Guid(Id);
            await Service.Delete(id);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}