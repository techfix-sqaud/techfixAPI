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
        public virtual DbSet<Quotes> Qoute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscribers>();
            modelBuilder.Entity<Quotes>();
        }

    }
}




