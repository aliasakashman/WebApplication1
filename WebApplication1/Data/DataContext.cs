using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.Models; // how to reference other classes
using Microsoft.EntityFrameworkCore; // package to use the database

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Value> Values { get; set; }
        
    }
}
