using Demo.DAL.Context;
using Demo.DAL.Entities;
using Demon.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MvcAppG02DbContext _dbcontext;
        public GenericRepository(MvcAppG02DbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task Add(T item)
        {
         await   _dbcontext.Set<T>().AddAsync(item);
            
        }

        public void Delete(T item)
        {
            _dbcontext.Set<T>().Remove(item);
           
        }

        public async Task<T> Get(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task <IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Employee)){
                return   (IEnumerable<T>)await _dbcontext.Employees.Include(E=>E.Department).ToListAsync();
            }
            else
            {
                return await _dbcontext.Set<T>().ToListAsync();
            }
            
        }

        public void Update(T item)
        {
            _dbcontext.Set<T>().Update(item);
           
        }
    }
}
