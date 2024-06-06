using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public PagedList<Book> GetAllBooks(BookParameters bookParameters, bool trackChanges)
        {
            var books =
            FindAll(trackChanges).FilterBooks(bookParameters.MinPrice,bookParameters.MaxPrice)
            .OrderBy(x => x.Id);
            return PagedList<Book>
                .ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public Book GetOneBook(int id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();

        //public void UpdateOneBook(Book book) => Update(book);

        public void UpdateOneBook(BookDtoForUpdate book)
        {
            //  
        }
    }
}
