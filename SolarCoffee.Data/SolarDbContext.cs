using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Data
{
    public class SolarDbContext : IdentityDbContext
    {
        public SolarDbContext() { }
        
        public SolarDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
