﻿using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Presistence.Contexts
{
    public class ETicaretAPIDbContext:DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Cusomters { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker:  Entitiler üzerinden yapılan değişiklikleri ya da yeni eklenen verinin yakalanmasını sağlayan propertilerdir.
            // Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ =>DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
