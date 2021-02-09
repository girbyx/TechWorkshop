using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechWorkshop.Server.Entities;
using TechWorkshop.Server.Entities.Interfaces;
using TechWorkshop.Shared.HttpResolvers;

namespace TechWorkshop.Server.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly UserResolverService _userResolver;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Entities.Client> Clients { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<PiecePurchaseOrder> PiecePurchaseOrders { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        public ApplicationDbContext(DbContextOptions options, UserResolverService userResolver)
            : base(options)
        {
            _userResolver = userResolver;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrder>().HasIndex(c => c.ClientId).IsUnique();
            modelBuilder.Entity<RepairOrder>().HasIndex(c => c.ClientId).IsUnique();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = Guid.NewGuid(), Username = "admin", Password = "admin", Email = "admin@admin.com", CreatedOn = DateTime.Now, CreatedBy = "system" });

            base.OnModelCreating(modelBuilder);
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields fields)
            {
                fields.CreatedOn = DateTime.Now;
                fields.CreatedBy = _userResolver.GetCurrentUserName();
            }

            return base.Add(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields fields)
            {
                fields.CreatedOn = DateTime.Now;
                fields.CreatedBy = _userResolver.GetCurrentUserName();
                fields.UpdatedOn = DateTime.Now;
                fields.UpdatedBy = _userResolver.GetCurrentUserName();
            }

            return base.Update(entity);
        }
    }
}