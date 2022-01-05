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
    public class TicketService : ITicketService
    {
        ITicketRepository _tickeRepository;
        IUnitOfWork _unitOfWork;
        public TicketService(ITicketRepository tickeRepository, IUnitOfWork unitOfWork)
        {
            _tickeRepository = tickeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(Ticket request)
        {
            var result = await _tickeRepository.Create(request);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await _tickeRepository.Delete(id);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _tickeRepository.GetAll();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _tickeRepository.GetById(id);
        }

        public async Task<PagedResult<Ticket>> GetPaging(GetPaggingRequest request)
        {
            return await _tickeRepository.GetPaging(request);
        }

        public async Task<int> Update(Ticket request)
        {
            return await _tickeRepository.Update(request);
        }
    }
}
