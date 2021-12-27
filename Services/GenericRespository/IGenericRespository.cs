using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.GenericRespository
{
    public interface IGenericRespository<T> where T : class
    {
        Task<int> Create(T request);
        Task<int> Update(T request);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<PagedResult<T>> GetPaging(GetPaggingRequest request);
    }
}
