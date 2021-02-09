using AutoMapper;
using Microsoft.Extensions.Configuration;
using TechWorkshop.Server.Data;

namespace TechWorkshop.Server.Services
{
    public interface IClientService : IBaseService<Entities.Client, object>
    {
    }

    public class ClientService : BaseService<Entities.Client, object>, IClientService
    {
        public ClientService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
        }
    }
}