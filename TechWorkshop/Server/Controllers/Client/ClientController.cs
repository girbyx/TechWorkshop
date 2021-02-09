using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechWorkshop.Server.Services;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Controllers.Client
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : BaseCatalogController<ClientController, Entities.Client, object,
        ClientViewModel>
    {
        public ClientController(ILogger<ClientController> logger, IMapper mapper, IClientService baseService)
            : base(logger, mapper, baseService)
        {
        }
    }
}