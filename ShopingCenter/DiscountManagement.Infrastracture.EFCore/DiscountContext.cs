﻿using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastracture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastracture.EFCore
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> customerDiscounts { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
