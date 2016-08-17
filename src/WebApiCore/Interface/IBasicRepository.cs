using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Interface
{
    public interface IBasicRepository<T>
    {
        //Having CRUD operations

        IEnumerable<T> GetAll();
        void Create(T obj);
        T Retrieve(string Id);
        void Update(T obj);
        void Delete(string Id);
    }
}
