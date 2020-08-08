using Microsoft.EntityFrameworkCore;
using OmerOzkan.Digiturk.Makale.DataAccess.Mapping;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;

namespace OmerOzkan.Digiturk.Makale.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KVV1JMS; database=DigiturkApi; user id=ebauser; password=3235860;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
