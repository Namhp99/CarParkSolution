using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface IParkinglotService
    {
        Task<int> Create(Parkinglot request);
        Task<int> Update(Parkinglot request);
        Task<int> Delete(int id);
        Task<IEnumerable<Parkinglot>> GetAll();
        Task<Parkinglot> GetById(int id);
        Task<PagedResult<Parkinglot>> GetPaging(GetPaggingRequest request);
    }
}
