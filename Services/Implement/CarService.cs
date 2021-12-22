using AutoMapper;
using Models.EF;
using Models.Entities;
using Models.View.Cars;
using Models.View.Pagging;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Implement
{
    public class CarService : GenericRespository<Car>, ICarService
    {

        public CarService(CarParkDbContext context)
            : base(context)
        {
        }

        public async Task<int> Create(CarCreateRequest request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarCreateRequest, Car>();
            });
            var mapper = config.CreateMapper();
            Car car = mapper.Map<Car>(request);
            _context.Cars.Add(car);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Car>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Cars
                        join t in _context.Parkinglots on p.ParkId equals t.ParkId
                        select new { p, t };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "LicensePlate")
                    query = query.Where(x => x.p.LicensePlate.Contains(request.Keyword));
                if (request.KeyType == "CarColor")
                    query = query.Where(x => x.p.CarColor.Contains(request.Keyword));
                if (request.KeyType == "CarType")
                    query = query.Where(x => x.p.CarType.Contains(request.Keyword));
                if (request.KeyType == "Company")
                    query = query.Where(x => x.p.Company.Contains(request.Keyword));
                else query = query.Where(x => x.p.LicensePlate.Contains(request.Keyword)
                                        || x.p.CarColor.Contains(request.Keyword)
                                        || x.p.Company.Contains(request.Keyword));
            }
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new Car()
                {
                    LicensePlate = i.p.LicensePlate,
                    CarColor = i.p.CarColor,
                    CarType = i.p.CarType,
                    Company = i.p.Company,
                    ParkId = i.p.ParkId,
                    Parkinglot = new Parkinglot()
                    {
                        ParkId = i.t.ParkId,
                        ParkArea = i.t.ParkArea,
                        ParkName = i.t.ParkName,
                        ParkPlace = i.t.ParkPlace,
                        ParkPrice = i.t.ParkPrice,
                        ParkStatus = i.t.ParkStatus,
                    }                   
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<Car>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<Car>> GetAllRecords()
        {
            // Select join
            var query = from p in _context.Cars
                            //join t in _context.Tickets on p.LicensePlate equals t.LicensePlate
                            //join l in _context.Parkinglots on p.ParkId equals l.ParkId
                        select new { p };
            //2.filter           
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query
                .Select(i => new Car()
                {
                    LicensePlate = i.p.LicensePlate,
                    CarColor = i.p.CarColor,
                    CarType = i.p.CarType,
                    Company = i.p.Company,
                    ParkId = i.p.ParkId,
                    Parkinglot = i.p.Parkinglot,
                    Tickets = i.p.Tickets

                }).ToList();
            //4. Select and projection
            var pagedResult = new PagedResult<Car>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(CarUpdateRequest request)
        {
            var car = await _context.Cars.FindAsync(request.LicensePlate);
            if (car == null) return -1;
            car.CarColor = request.CarColor;
            car.CarType = request.CarType;
            car.Company = request.Company;
            car.ParkId = request.ParkId;
            return await _context.SaveChangesAsync();
        }
    }
}
