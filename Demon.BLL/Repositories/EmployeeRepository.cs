using Demo.DAL.Context;
using Demo.DAL.Entities;
using Demon.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MvcAppG02DbContext _dbContext;

        public EmployeeRepository(MvcAppG02DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address == address);
        }

        public IQueryable<Employee> SearchEmployeeByName(string name)
        {
         return   _dbContext.Employees.Where(E=>E.Name.ToLower().Contains( name.ToLower()));
        }
    }
}
