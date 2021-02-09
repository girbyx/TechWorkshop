using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechWorkshop.Server.Services;

namespace TechWorkshop.Server.Controllers
{
    public class BaseDetailController<TController, TEntity, THistory, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class, new()
        where THistory : class
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity, THistory> _baseService;

        public BaseDetailController(ILogger<TController> logger, IMapper mapper, IBaseService<TEntity, THistory> baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [Authorize]
        [HttpGet]
        public TViewModel Get(Guid id)
        {
            var result = _mapper.Map<TViewModel>(_baseService.Get(id));
            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("GetEmpty")]
        public TViewModel GetEmpty()
        {
            var result = _mapper.Map<TViewModel>(new TEntity());
            return result;
        }
    }
}