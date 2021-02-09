using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechWorkshop.Server.Services;

namespace TechWorkshop.Server.Controllers
{
    public class BaseCatalogController<TController, TEntity, THistory, TViewModel> : ControllerBase
        where TController : class
        where TEntity : class
        where THistory : class
        where TViewModel : class
    {
        private readonly ILogger<TController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity, THistory> _baseService;

        public BaseCatalogController(ILogger<TController> logger, IMapper mapper, IBaseService<TEntity, THistory> baseService)
        {
            _logger = logger;
            _mapper = mapper;
            _baseService = baseService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<TViewModel> Get()
        {
            var result = _baseService.GetAll()
                .Select(_mapper.Map<TViewModel>);
            return result;
        }

        [Authorize]
        [HttpPost]
        public Guid Post(TViewModel dto)
        {
            _baseService.Save(_mapper.Map<TEntity>(dto), out Guid id);
            return id;
        }

        [Authorize]
        [HttpPost]
        [Route("PostFiles")]
        public int PostFiles([FromForm] Guid id, [FromForm] string[] files)
        {
            var result = 0;
            if (files.Any())
                result = _baseService.SaveAttachments(files, id);
            return result;
        }

        [Authorize]
        [HttpDelete]
        public int Delete(Guid id)
        {
            return _baseService.Delete(id);
        }

        [Authorize]
        [HttpPut]
        public Guid Put(TViewModel dto)
        {
            _baseService.Save(_mapper.Map<TEntity>(dto), out Guid id);
            return id;
        }
    }
}