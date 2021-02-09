using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechWorkshop.Server.Services;
using TechWorkshop.Shared.ViewModels;

namespace TechWorkshop.Server.Controllers.Client
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ClientDetailController : BaseDetailController<ClientDetailController, Entities.Client, object,
            ClientViewModel>
    {
        public ClientDetailController(ILogger<ClientDetailController> logger, IMapper mapper,
            IClientService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}