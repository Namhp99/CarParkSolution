using Microsoft.EntityFrameworkCore;
using Models.EF;
using Models.Entities;
using Models.View.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CarParkDbContext _context;
        public EmployeeService(CarParkDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(EmployeeCreateRequest request)
        {
            var employee = new Employee()
            {
                EmployeeName = request.EmployeeName,
                EmployeeEmail = request.EmployeeEmail,
                EmployeeAddress = request.EmployeeAddress,
                EmployeePhone = request.EmployeePhone,
                Sex = request.Sex,
                EmployeeBirthdate = request.EmployeeBirthdate,
                Account = request.Account,
                Password = request.Password,
                Department = request.Department,
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.EmployeeId;
        }

        public async Task<int> Delete(int employeeId)
        {
            var emp = await _context.Employees.FindAsync(employeeId);
            if (emp == null) throw new Exception("Khong tim thay nhan vien");
            _context.Employees.Remove(emp);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeView>> GetAll()
        {
            return await _context.Employees.Select(i => new EmployeeView()
            {
                EmployeeId = i.EmployeeId,
                EmployeeAddress = i.EmployeeAddress,
                EmployeeBirthdate = i.EmployeeBirthdate,
                EmployeeEmail = i.EmployeeEmail,
                EmployeeName = i.EmployeeName,
                EmployeePhone = i.EmployeePhone,
                Department = i.Department,
                Sex = i.Sex,
                Account = i.Account,
                Password = i.Password
                
            }).ToListAsync();
        }

        public async Task<EmployeeView> GetById(int Id)
        {
            var emp = await _context.Employees.FindAsync(Id);
            if (emp == null) throw new Exception("Khong tim thay nhan vien");
            var viewEmp = new EmployeeView()
            {
                EmployeeId = emp.EmployeeId,
                Account = emp.Account,
                Password = emp.Password,
                EmployeeName = emp.EmployeeName,
                EmployeeAddress = emp.EmployeeAddress,
                EmployeeBirthdate = emp.EmployeeBirthdate,
                EmployeeEmail = emp.EmployeeEmail,
                EmployeePhone = emp.EmployeePhone,
                Department = emp.Department,
                Sex = emp.Sex,
            };
            return viewEmp;
        }

        public async Task<PagedResult<EmployeeView>> GetEmployeeByAddress(GetEmployeePaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.EmployeeAddress.Contains(request.Keyword));
            //3.Paging
            int tatalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new EmployeeView()
                {
                    EmployeeId = i.p.EmployeeId,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Department = i.p.Department,
                    Sex = i.p.Sex,
                    Account = i.p.Account,
                    Password = i.p.Password
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeView>()
            {
                TotalRecord = tatalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<EmployeeView>> GetEmployeeByDepartment(GetEmployeePaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Department.Contains(request.Keyword));
            //3.Paging
            int tatalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new EmployeeView()
                {
                    EmployeeId = i.p.EmployeeId,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Department = i.p.Department,
                    Sex = i.p.Sex,
                    Account = i.p.Account,
                    Password = i.p.Password
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeView>()
            {
                TotalRecord = tatalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<EmployeeView>> GetEmployeeByEmail(GetEmployeePaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.EmployeeEmail.Contains(request.Keyword));
            //3.Paging
            int tatalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new EmployeeView()
                {
                    EmployeeId = i.p.EmployeeId,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Department = i.p.Department,
                    Sex = i.p.Sex,
                    Account = i.p.Account,
                    Password = i.p.Password
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeView>()
            {
                TotalRecord = tatalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<EmployeeView>> GetEmployeeByPhone(GetEmployeePaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.EmployeePhone.Contains(request.Keyword));
            //3.Paging
            int tatalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new EmployeeView()
                {
                    EmployeeId = i.p.EmployeeId,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Department = i.p.Department,
                    Sex = i.p.Sex,
                    Account = i.p.Account,
                    Password = i.p.Password
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeView>()
            {
                TotalRecord = tatalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<EmployeeView>> GetEmployeePaging(GetEmployeePaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Employees
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.EmployeeName.Contains(request.Keyword)
                                 || x.p.EmployeePhone.Contains(request.Keyword)
                                 || x.p.EmployeeEmail.Contains(request.Keyword)
                                 || x.p.EmployeeAddress.Contains(request.Keyword)
                                 || x.p.Department.Contains(request.Keyword)
                                 || x.p.Sex.Contains(request.Keyword));     
            //3.Paging
            int tatalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new EmployeeView()
                {
                    EmployeeId = i.p.EmployeeId,
                    EmployeeAddress = i.p.EmployeeAddress,
                    EmployeeBirthdate = i.p.EmployeeBirthdate,
                    EmployeeEmail = i.p.EmployeeEmail,
                    EmployeeName = i.p.EmployeeName,
                    EmployeePhone = i.p.EmployeePhone,
                    Department = i.p.Department,
                    Sex = i.p.Sex,
                    Account = i.p.Account,
                    Password = i.p.Password
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<EmployeeView>()
            {
                TotalRecord = tatalRow,
                Items = data
            };
            return pagedResult;
        }
      

        public async Task<int> Update(EmployeeUpdateRequest request)
        {
            var emp = await _context.Employees.FindAsync(request.EmployeeId);
            if (emp == null) throw new Exception("Khong tim thay nhan vien");
            emp.Department = request.Department;
            emp.EmployeeAddress = request.EmployeeAddress;
            emp.EmployeeBirthdate = request.EmployeeBirthdate;
            emp.EmployeeEmail = request.EmployeeEmail;
            emp.EmployeeName = request.EmployeeName;
            emp.EmployeePhone = request.EmployeePhone;
            emp.Sex = request.Sex;
            return await _context.SaveChangesAsync();
        }
    }
}
