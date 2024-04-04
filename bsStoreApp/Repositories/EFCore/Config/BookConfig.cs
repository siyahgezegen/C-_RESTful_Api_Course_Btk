using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, title = "Hacivat ve Karagöz", price = 115 },
                new Book { Id = 2, title = "Mesneviler", price = 150 },
                new Book { Id = 3, title = "Devlet", price = 501 }
                );
        }
    }
}
