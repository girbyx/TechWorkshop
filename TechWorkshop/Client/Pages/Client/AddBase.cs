using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Client.Pages.Client
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ClientViewModel Record { get; set; } = new ClientViewModel();

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Add(Record);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}