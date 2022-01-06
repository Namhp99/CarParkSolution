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
    public class CarService : ICarService
    {
        ICarRepository _carRepository;
        IUnitOfWork _unitOfWork;
        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Create(Car request)
        {
            return await _carRepository.Create(request);
        }

        public async Task<int> Delete(int id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<PagedResult<Car>> Find(GetPaggingRequest request)
        {
            return await _carRepository.Find(request);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carRepository.GetAll();
        }

        public async Task<PagedResult<Car>> GetAllRecords()
        {
            return await _carRepository.GetAllRecords();
        }

        public async Task<Car> GetByCar(string request)
        {
            return await _carRepository.GetByCar(request);
        }

        public async Task<PagedResult<Car>> GetPaging(GetPaggingRequest request)
        {
            return await _carRepository.GetPaging(request);
        }

        public async Task<int> Update(Car request)
        {
            return await _carRepository.Update(request);
        }
    }
}
