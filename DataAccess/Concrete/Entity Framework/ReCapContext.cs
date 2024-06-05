using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCap;Trusted_Connection=True;");
        }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Color> Colors{ get; set; }
    }
}
