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
    public class DepartmentRepository :GenericRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepository(MvcAppG02DbContext dbContext) : base(dbContext)
        {

        }

    }
}
