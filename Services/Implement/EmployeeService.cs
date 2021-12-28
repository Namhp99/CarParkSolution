using Models.EF;
using Models.Entities;
using Models.View.Employees;
using Models.View.Pagging;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Services.Service
{
    public class EmployeeService : GenericRepository<Employee>, IEmployeeService
    {

        public EmployeeService(CarParkDbContext context)
            : base(context)
        {
        }

        //public async Task<int> Create(EmployeeCreateRequest request)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<EmployeeCreateRequest, Employee>();
        //    });
        //    var mapper = config.CreateMapper();
        //    Employee employee = mapper.Map<Employee>(request);
        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();
        //    return employee.EmployeeId;
        //}

        public async Task<PagedResult<Employee>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "Account")
                    query = query.Where(x => x.p.Account.Contains(request.Keyword));
                if (request.KeyType == "Department")
                    query = query.Where(x => x.p.Department.Contains(request.Keyword));
                if (request.KeyType == "EmployeeAddress")
                    query = query.Where(x => x.p.EmployeeAddress.Contains(request.Keyword));
                if (request.KeyType == "EmployeeName")
                    query = query.Where(x => x.p.EmployeeName.Contains(request.Keyword));
                if (request.KeyType == "EmployeePhone")
                    query = query.Where(x => x.p.EmployeePhone.Contains(request.Keyword));
                if (request.KeyType == "Sex")
                    query = query.Where(x => x.p.Sex.Contains(request.Keyword));
                else query = query.Where(x => x.p.Account.Contains(request.Keyword)
                        || x.p.Department.Contains(request.Keyword)
                        || x.p.EmployeeAddress.Contains(request.Keyword)
                        || x.p.EmployeeName.Contains(request.Keyword)
                        || x.p.EmployeePhone.Contains(request.Keyword)
                        || x.p.Sex.Contains(request.Keyword));
            }

            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new Employee()
                {
                    EmployeeId = i.p.EmployeeId,
                    Account = i.p.Account,
                    Password = i.p.Password,
                    Department = i.p.Department,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Sex = i.p.Sex,
                    
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<Employee>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        //public async Task<int> Update(EmployeeUpdateRequest request)
        //{
        //    var employee = await _context.Employees.FindAsync(request.EmployeeId);
        //    if (employee == null) return -1;
        //    employee.Account = request.Account;
        //    employee.Password = request.Password;
        //    employee.EmployeeName = request.EmployeeName;
        //    employee.EmployeeEmail = request.EmployeeEmail;
        //    employee.EmployeeBirthdate = request.EmployeeBirthdate;
        //    employee.Department = request.Department;
        //    employee.EmployeePhone = request.EmployeePhone;
        //    employee.Sex = request.Sex;
        //    employee.EmployeeAddress = request.EmployeeAddress;
        //    return await _context.SaveChangesAsync();
        //}
    }
}
