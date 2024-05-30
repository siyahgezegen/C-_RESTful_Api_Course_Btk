using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    /*
     Farklı farklı sınıflar üzerinde aynı işlemleri yapabilmek için Generic Programlama yaklaşımı var
     trackChanges değişikliklerin incelenip incelenmemesi için kullanılacak
     */
    public interface IRepositoryBase<T>
    {
        // CRUD operations
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
