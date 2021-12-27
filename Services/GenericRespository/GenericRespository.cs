using Microsoft.EntityFrameworkCore;
using Models.EF;
using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.GenericRespository
{
    public class GenericRespository<T> : IGenericRespository<T> where T : class
    {
        protected readonly CarParkDbContext _context;
        public GenericRespository( CarParkDbContext context)
        {
            _context = context;
        }


        public async Task<int> Create(T request)
        {
            _context.Set<T>().Add(request);
            var result = await _context.SaveChangesAsync();
            return result;
        }



        public async Task<int> Delete(int id)
        {
            var result =  await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(result);
            return await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<PagedResult<T>> GetPaging(GetPaggingRequest request)
        {
            //1/Select join
            var query = _context.Set<T>()
                .AsQueryable();
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            //4.Select and projection
            var pagedResult = new PagedResult<T>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(T request)
        {
            _context.Set<T>().Attach(request);
            _context.Entry(request).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;
        }

    }

}
