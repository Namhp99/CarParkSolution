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
    public class BookingOfficeService : IBookingOfficeService
    {
        private readonly IBookingOfficeRepository _bookingOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookingOfficeService(IBookingOfficeRepository bookingOfficeRepository, IUnitOfWork unitOfWork)
        {
            _bookingOfficeRepository = bookingOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(BookingOffice request)
        {
            return await _bookingOfficeRepository.Create(request);
        }

        public async Task<int> Delete(int id)
        {
            return await _bookingOfficeRepository.Delete(id);
        }

        public async Task<PagedResult<BookingOffice>> Find(GetPaggingRequest request)
        {
            return await _bookingOfficeRepository.Find(request);
        }

        public async Task<IEnumerable<BookingOffice>> GetAll()
        {
            return await _bookingOfficeRepository.GetAll();
        }

        public async Task<PagedResult<BookingOffice>> GetAllRecords()
        {
            return await _bookingOfficeRepository.GetAllRecords();
        }

        public async Task<BookingOffice> GetById(int id)
        {
            return await _bookingOfficeRepository.GetById(id);
        }

        public async Task<PagedResult<BookingOffice>> GetPaging(GetPaggingRequest request)
        {
            return await _bookingOfficeRepository.GetPaging(request);
        }

        public async Task<int> Update(BookingOffice request)
        {
            return await _bookingOfficeRepository.Update(request);
        }
    }
}
