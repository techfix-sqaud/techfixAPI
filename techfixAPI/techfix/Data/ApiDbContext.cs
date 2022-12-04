using Microsoft.Win32.SafeHandles;
using System.Numerics;
using System.Security.AccessControl;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using techfix.Models;

namespace techfix.Data
{
      public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Subscribers> Subscriber { get; set; }
        public virtual DbSet<Quotes> Quote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscribers>(S => {
            S.Property(s => s.id).ValueGeneratedOnAdd();
            S.HasIndex(s => s.Email).IsUnique();
        });
            modelBuilder.Entity<Quotes>(Q => {
                Q.Property(q => q.id).ValueGeneratedOnAdd();           
            });
        }

    }
}




