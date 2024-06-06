using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        PagedList<Book> GetAllBooks(BookParameters bookParameters, bool trackChanges);
        Book GetOneBook(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(BookDtoForUpdate book);
        void DeleteOneBook(Book book);

    }
}
