using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class CarRentCompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database= CarRentCompany; Trusted_Connection = true");

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<RealCustomer> RealCustomers { get; set; }
        public DbSet<LegalCustomer> LegalCustomers { get; set; }
        //public DbSet<AbstractCustomer> Customers { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
