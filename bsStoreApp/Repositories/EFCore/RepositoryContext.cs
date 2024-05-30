using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        //Context veriye erişim noktasında, veritabanı oluşturulması, yansıtılması noktasında
        //ihtiyacımız olacak alandır.

        //ne işe yarar ? ..: veritabını db context olarak düşünücez 
        //Özet olarak
        //model yapıları üzerinden veritabanı işlemlerinin yapılması
        public DbSet<Book> Books { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
