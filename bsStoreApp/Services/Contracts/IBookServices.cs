﻿using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    
    public interface IBookServices
    {
        (IEnumerable<Book> books,MetaData metaData) GetAllBooks(BookParameters bookParameters, bool trackChanges);
        Book GetBook(int id, bool trackChanges);
        Book CreateOneBook(Book book);
        void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges);
        void DeleteOneBook(int id, bool trackChanges);

    }
}
