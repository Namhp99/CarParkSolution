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
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TripService(ITripRepository tripRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(Trip request)
        {
            return await  _tripRepository.Create(request);
        }

        public async Task<int> Delete(int id)
        {
            return await _tripRepository.Delete(id);
        }

        public async Task<PagedResult<Trip>> Find(GetPaggingRequest request)
        {
            return await _tripRepository.Find(request);
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _tripRepository.GetAll();
        }

        public async Task<PagedResult<Trip>> GetAllRecords()
        {
            return await _tripRepository.GetAllRecords();
        }

        public async Task<Trip> GetById(int id)
        {
            return await _tripRepository.GetById(id);
        }

        public async Task<PagedResult<Trip>> GetPaging(GetPaggingRequest request)
        {
            return await _tripRepository.GetPaging(request);
        }

        public async Task<int> Update(Trip request)
        {
            return await _tripRepository.Update(request);
        }
    }
}
