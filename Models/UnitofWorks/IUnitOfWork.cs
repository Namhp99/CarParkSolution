using Models.Repository.Interfaces;
using System.Threading.Tasks;

namespace Models.UnitofWorks
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        ITripRepository Trips { get; }
        IBookingOfficeRepository BookingOffices { get; }
        IEmployeeRepository Employees { get; }
        IParkinglotRepository Parkinglots { get; }
        ITicketRepository Tickets { get; }
        Task Save();
    }
}
