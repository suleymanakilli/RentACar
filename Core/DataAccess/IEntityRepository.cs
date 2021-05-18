using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity,new() //T class olacak IEntity'den türemiş olacak ve newlenebilir olacak.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
