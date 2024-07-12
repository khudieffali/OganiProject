using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContexts
{
    public class OganiDataContext(DbContextOptions<OganiDataContext> options):DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OganiDataContext).Assembly);
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
        public DbSet<ProductToPicture> ProductToPictures { get; set; }
        public DbSet<ProductToSize> ProductToSizes { get; set; }
       

    }
}
