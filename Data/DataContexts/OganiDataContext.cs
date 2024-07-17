using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using Infrastructure.Services.Abstarcts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContexts
{
    public class OganiDataContext(DbContextOptions<OganiDataContext> options,IDateTimeService dateTimeService):DbContext(options)
    {
        private readonly IDateTimeService _dateTimeService=dateTimeService;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OganiDataContext).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken token=new())
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();
            if(changes != null)
            {
                foreach (var change in changes.Where(x=>x.State==EntityState.Added ||
                x.State==EntityState.Modified || 
                x.State==EntityState.Deleted)) 
                {
                    switch (change.State)
                    {   
                        case EntityState.Added:
                            change.Entity.CreatedAt = _dateTimeService.ExecutingTime;
                            change.Entity.CreatedBy = 1;
                            break;
                        case EntityState.Modified:
                            change.Entity.UpdatedAt = _dateTimeService.ExecutingTime;
                            change.Entity.UpdatedBy = 2;
                            change.Property(x => x.CreatedBy).IsModified = false;
                            change.Property(x=>x.CreatedAt).IsModified=false;
                            break;
                        case EntityState.Deleted:
                            change.State= EntityState.Modified;
                            change.Entity.DeletedAt= _dateTimeService.ExecutingTime;    
                            change.Entity.DeletedBy= 3;
                            change.Property(x => x.CreatedBy).IsModified = false;
                            change.Property(x => x.CreatedAt).IsModified = false;
                            change.Property(x => x.UpdatedAt).IsModified = false;
                            change.Property(x => x.UpdatedBy).IsModified = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(token);
        }
        public DbSet<Organic> Organics { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogToTag> BlogToTags { get; set; }
        public DbSet<ProductToColor> ProductToColors { get; set; }
        public DbSet<ProductToSize> ProductToSizes { get; set; }
       

    }
}
