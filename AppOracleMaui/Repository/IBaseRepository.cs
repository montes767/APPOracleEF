using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppOracleMaui.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : class, new()
    {
        void Save(T item);
        
        Task<List<T>> GetAll();
       

    }
}
