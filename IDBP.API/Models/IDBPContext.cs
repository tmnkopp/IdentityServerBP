using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDBP.API.Models
{
    public class IDBPContext : DbContext
    {
        public IDBPContext(DbContextOptions<IDBPContext> options) :base(options)
        { 
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
