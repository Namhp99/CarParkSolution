using Models.Entities;
using Models.Repository.Interfaces;
using Models.UnitofWorks;
using Models.View.Pagging;
using Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ImplementService
{
    public class ParkinglotService : IParkinglotService
    {
        IParkinglotRepository _parkinglotRepository;
        IUnitOfWork _unitOfWork;
        public ParkinglotService(IParkinglotRepository parkinglotRepository, IUnitOfWork unitOfWork)
        {
            _parkinglotRepository = parkinglotRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(Parkinglot request)
        {
            var result = await _parkinglotRepository.Create(request);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await _parkinglotRepository.Delete(id);
        }

        public async Task<IEnumerable<Parkinglot>> GetAll()
        {
            return await _parkinglotRepository.GetAll();
        }

        public async Task<Parkinglot> GetById(int id)
        {
            return await _parkinglotRepository.GetById(id);
        }

        public async Task<PagedResult<Parkinglot>> GetPaging(GetPaggingRequest request)
        {
            return await _parkinglotRepository.GetPaging(request);
        }

        public async Task<int> Update(Parkinglot request)
        {
            return await _parkinglotRepository.Update(request);
        }
    }
}
