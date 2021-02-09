using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace TechWorkshop.Client.Shared.Services
{
    public class BaseDependentService<TViewModel> : BaseCatalogService<TViewModel>, IBaseDependentService
        where TViewModel : class
    {
        public BaseDependentService(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
        }
    }
}