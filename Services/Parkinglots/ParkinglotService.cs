using Microsoft.EntityFrameworkCore;
using Models.EF;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Parkinglots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parkinglots
{
    public class ParkinglotService : IParkinglotService
    {
        private readonly CarParkDbContext _context;
        public ParkinglotService(CarParkDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ParkinglotCreateRequest request)
        {
            var parkingLot = new Parkinglot()
            {
                ParkName = request.ParkName,
                ParkPlace = request.ParkPlace,
                ParkArea =request.ParkArea,
                ParkPrice = request.ParkPrice,
                ParkStatus = request.ParkStatus,
            };
            _context.Parkinglots.Add(parkingLot);
            await _context.SaveChangesAsync();
            return parkingLot.ParkId;
        }

        public async Task<int> Delete(int Id)
        {
            var parkingLot = await _context.Parkinglots.FindAsync(Id);
            if (parkingLot == null) throw new Exception("Khong tim thay bai dau xe");
            _context.Parkinglots.Remove(parkingLot);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ParkinglotView>> GetAll()
        {
            return await _context.Parkinglots.Select(i => new ParkinglotView()
            {
                ParkId = i.ParkId,
                ParkStatus = i.ParkStatus,
                ParkPrice = i.ParkPrice,
                ParkArea = i.ParkArea,
                ParkName = i.ParkName,
                ParkPlace = i.ParkPlace
            }).ToListAsync();
        }

        public async Task<ParkinglotView> GetById(int Id)
        {
            var parkingLot = await _context.Parkinglots.FindAsync(Id);
            if (parkingLot == null) throw new Exception("Khong tim thay bai dau xe");
            var parkingLotView = new ParkinglotView()
            {
                ParkPlace = parkingLot.ParkPlace,
                ParkName = parkingLot.ParkName,
                ParkArea = parkingLot.ParkArea,
                ParkPrice = parkingLot.ParkPrice,
                ParkStatus = parkingLot.ParkStatus,
                ParkId = parkingLot.ParkId
            };
            return parkingLotView;
        }

        public Task<PagedResult<ParkinglotView>> GetParkinglotPaging(GetPaggingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ParkinglotUpdateRequest request)
        {
            var parkingLot = await _context.Parkinglots.FindAsync(request.ParkId);
            if (parkingLot == null) throw new Exception("Khong tim thay bai dau xe");
            parkingLot.ParkName = request.ParkName;
            parkingLot.ParkPlace = request.ParkPlace;
            parkingLot.ParkPrice = request.ParkPrice;
            parkingLot.ParkStatus = request.ParkStatus;
            parkingLot.ParkArea = request.ParkArea;
            return await _context.SaveChangesAsync();
        }
    }
}
