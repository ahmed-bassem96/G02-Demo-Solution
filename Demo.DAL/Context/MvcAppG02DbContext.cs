using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class MvcAppG02DbContext:IdentityDbContext<ApplicationUser>
    {
        public MvcAppG02DbContext(DbContextOptions<MvcAppG02DbContext> options):base(options) 
        {

        }
        
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KH35RQN\\MSSQLSERVER01; databse=MvcAppG02; trusted_connection= true;");
        }*/
       public DbSet<Department> Departments { get; set; }
       public DbSet<Employee> Employees { get; set; }

       /* public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }*/
    }
}
