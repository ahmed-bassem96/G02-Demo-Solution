using Demo.DAL.Context;
using Demon.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcAppG02DbContext _dbContext;

        public IEmployeeRepository EmployeeRepository { get; set; }

        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitOfWork(MvcAppG02DbContext dbContext)
        {
            EmployeeRepository=new EmployeeRepository(dbContext);
            DepartmentRepository= new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
