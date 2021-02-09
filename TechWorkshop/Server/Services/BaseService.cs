using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CG.Web.MegaApiClient;
using Microsoft.Extensions.Configuration;
using TechWorkshop.Server.Data;
using TechWorkshop.Server.Entities;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Server.Extensions;

namespace TechWorkshop.Server.Services
{
    public interface IBaseService<TEntity, out THistory> where TEntity : class where THistory : class
    {
        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> function);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllForResolver();
        TEntity Get(Guid id);
        int Save(TEntity entity, out Guid id);
        int SaveAttachments(string[] files, Guid id);
        int Delete(Guid id);
    }

    public class BaseService<TEntity, THistory> : IBaseService<TEntity, THistory>
        where TEntity : class
        where THistory : class
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BaseService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> function)
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .Where(function)
                .ToList();
            return records;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .ToList();
            return records;
        }

        public virtual IEnumerable<TEntity> GetAllForResolver()
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .ToList();
            return records;
        }

        public virtual TEntity Get(Guid id)
        {
            var records = _dbContext.Set<TEntity>()
                .IncludeAll()
                .Single(x => (x as IIdentityFields).Id == id);
            return records;
        }

        public virtual int Save(TEntity entity, out Guid id)
        {
            if (((IIdentityFields) entity).Id == Guid.Empty)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            id = ((IIdentityFields) entity).Id;
            return _dbContext.SaveChanges();
        }

        public virtual int SaveAttachments(string[] files, Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(Guid id)
        {
            var record = _dbContext
                .Set<TEntity>()
                .First(x => (x as IIdentityFields).Id == id);
            _dbContext.Remove(record);
            return _dbContext.SaveChanges();
        }

        protected int SaveToFileHosting(string[] files, int id, string folderPathConst)
        {
            // open mega.nz connection
            MegaApiClient client = new MegaApiClient();
            string megaUsername = _configuration[Shared.Constants.UsernameConfigPath];
            string megaPassword = _configuration[Shared.Constants.PasswordConfigPath];
            client.Login(megaUsername, megaPassword);

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // prepare string
                    var splitString = file.Split("||");
                    var fileBase64String = splitString.First();

                    // prepare file
                    var bytes = Convert.FromBase64String(fileBase64String);
                    using MemoryStream stream = new MemoryStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    // determine file name
                    var fileName = splitString.Length > 2 ? splitString[1] : Guid.NewGuid().ToString();

                    // save file to mega.nz
                    var folderPath = $"{folderPathConst}{id}";
                    IEnumerable<INode> nodes = client.GetNodes();
                    INode cloudFolder =
                        nodes.SingleOrDefault(x => x.Type == NodeType.Directory && x.Name == folderPath);

                    if (cloudFolder == null)
                    {
                        INode root = nodes.Single(x => x.Type == NodeType.Root);
                        cloudFolder = client.CreateFolder(folderPath, root);
                    }

                    var extension = splitString.Last();
                    INode cloudFile = client.Upload(stream, $"{fileName}.{extension}", cloudFolder);
                    Uri downloadLink = client.GetDownloadLink(cloudFile);

                    // prepare entity
                    var entity = new Attachment
                    {
                        Name = fileName,
                        Url = downloadLink.AbsoluteUri,
                        ExtensionType = extension
                    };
                    // DetermineEntityNavigation(entity, folderPathConst, id);

                    _dbContext.Add(entity);
                }
            }

            // close mega.nz connection
            client.Logout();

            return _dbContext.SaveChanges();
        }

        // protected void DetermineEntityNavigation(Attachment entity, string folderPathConst, int id)
        // {
        //     if (folderPathConst == Shared.Constants.ProjectFolderPath)
        //     {
        //         entity.ProjectId = id;
        //     }
        //     else if (folderPathConst == Shared.Constants.CostFolderPath)
        //     {
        //         entity.CostId = id;
        //     }
        //     else if (folderPathConst == Shared.Constants.GainFolderPath)
        //     {
        //         entity.GainId = id;
        //     }
        //     else if (folderPathConst == Shared.Constants.LossFolderPath)
        //     {
        //         entity.LossId = id;
        //     }
        // }
    }
}