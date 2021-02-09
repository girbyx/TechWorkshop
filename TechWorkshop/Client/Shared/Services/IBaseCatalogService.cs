using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace TechWorkshop.Client.Shared.Services
{
    public interface IBaseCatalogService<TViewModel> where TViewModel : class
    {
        Task<string> GetCurrentUserName();
        Task<IEnumerable<TViewModel>> GetList();
        Task<IEnumerable<TViewModel>> GetHistory(Guid id);
        Task<TViewModel> Get(Guid id);
        Task<TViewModel> GetEmpty();
        Task<Guid> Add(TViewModel record);
        Task AddFiles(Guid id, IBrowserFile[] files);
        Task Delete(Guid id);
        Task DeleteAttachment(Guid id);
        Task Archive(Guid id);
        Task<Guid> Update(TViewModel record);
        Task Return();
    }
}