using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
   
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        // Lazy desing 
        private readonly Lazy<IBookRepository> _bookRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(new BookRepository(_context));
        }
        // Nesne kullanıldığı anda new'lenme işlemini yapmayı sağlar.
        public IBookRepository Book => _bookRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
