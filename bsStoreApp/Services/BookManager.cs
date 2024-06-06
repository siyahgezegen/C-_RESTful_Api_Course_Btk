using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public Book CreateOneBook(Book book)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }
        public void DeleteOneBook(int id, bool trackChanges)
        {
            // check entity
            var entity = _manager.Book.GetOneBook(id, trackChanges);
            if (entity is null)
                throw new Exception($"Book with id:{id} could not found");


            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }
        public (IEnumerable<Book> books, MetaData metaData) GetAllBooks(BookParameters bookParameters,bool trackChanges)
        {
            if(!bookParameters.ValidPriceRange)
                throw new PriceOutoOfRangeBadRequestException();

            var books = _manager.Book.GetAllBooks(bookParameters,trackChanges);
            return (books,books.MetaData);
        }
        public Book GetBook(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBook(id, trackChanges);
        }
        public void UpdateOneBook(int id, BookDtoForUpdate book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBook(id, trackChanges);
            if (entity is null)
                throw new Exception($"Book with id:{id} could not found");
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            entity = _mapper.Map<Book>(book);

            _manager.Book.Update(entity);
            _manager.Save();
        }

       
    }
}
