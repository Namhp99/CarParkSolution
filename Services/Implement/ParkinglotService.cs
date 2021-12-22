using Models.EF;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Parkinglots;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Services.Implement
{
    public class ParkinglotService : GenericRespository<Parkinglot>, IParkinglotService
    {

        public ParkinglotService(CarParkDbContext context)
            : base(context)
        {
        }

        public async Task<int> Create(ParkinglotCreateRequest request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParkinglotCreateRequest, Parkinglot>();
            });
            var mapper = config.CreateMapper();
            Parkinglot parkinglot = mapper.Map<Parkinglot>(request);
            _context.Parkinglots.Add(parkinglot);
            await _context.SaveChangesAsync();
            return parkinglot.ParkId;
        }

        public async Task<PagedResult<Parkinglot>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Parkinglots
                        join c in _context.Cars on p.ParkId equals c.ParkId
                        select new { p, c };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "ParkName")
                    query = query.Where(x => x.p.ParkName.Contains(request.Keyword));
                if (request.KeyType == "ParkPlace")
                    query = query.Where(x => x.p.ParkName.Contains(request.Keyword));
                if (request.KeyType == "ParkStatus")
                    query = query.Where(x => x.p.ParkStatus.Contains(request.Keyword));
                else query = query.Where(x => x.p.ParkName.Contains(request.Keyword)
                        || x.p.ParkPlace.Contains(request.Keyword)
                        || x.p.ParkStatus.Contains(request.Keyword));
            }
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new Parkinglot()
                {
                    ParkId = i.p.ParkId,
                    ParkArea = i.p.ParkArea,
                    ParkName = i.p.ParkName,
                    ParkPlace = i.p.ParkPlace,
                    ParkPrice = i.p.ParkPrice,
                    ParkStatus = i.p.ParkStatus,               
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<Parkinglot>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<Parkinglot>> GetAllRecords()
        {
            //1/Select join
            var query = from p in _context.Parkinglots
                        select new { p };
            //2.filter           
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query
                .Select(i => new Parkinglot()
                {
                    ParkId = i.p.ParkId,
                    ParkArea = i.p.ParkArea,
                    ParkName = i.p.ParkName,
                    ParkPlace = i.p.ParkPlace,
                    ParkPrice = i.p.ParkPrice,
                    ParkStatus =i.p.ParkStatus,
                    Cars = i.p.Cars


                }).ToList();
            //4. Select and projection
            var pagedResult = new PagedResult<Parkinglot>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(ParkinglotUpdateRequest request)
        {
            var parkinglot = await _context.Parkinglots.FindAsync(request.ParkId);
            if (parkinglot == null) return -1;
            parkinglot.ParkArea = request.ParkArea;
            parkinglot.ParkName = request.ParkName;
            parkinglot.ParkPlace = request.ParkPlace;
            parkinglot.ParkPrice = request.ParkPrice;
            parkinglot.ParkStatus = request.ParkStatus;
            return await _context.SaveChangesAsync();
        }
    }
}