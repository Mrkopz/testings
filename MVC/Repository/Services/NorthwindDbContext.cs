using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public NorthwindDbContext()
            : base("ConnectionString")
        {
            //enable migration ไม่ให้สร้าง database ให้
            Database.SetInitializer<NorthwindDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>()
                .ToTable("Employees")
                .HasKey(e => e.EmployeeId);
        }
    }
}
