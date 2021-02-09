using System.Net.Http;
using Microsoft.AspNetCore.Components;
using TechWorkshop.Client.Shared.Services;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Client.Pages.Client
{
    public interface IService : IBaseCatalogService<ClientViewModel>
    {

    }

    public class Service : BaseCatalogService<ClientViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Client";
            DetailControllerName = "ClientDetail";
        }
    }
}