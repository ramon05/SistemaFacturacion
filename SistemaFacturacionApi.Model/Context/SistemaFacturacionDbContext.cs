using Microsoft.EntityFrameworkCore;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Context
{
    public class SistemaFacturacionDbContext : BaseDbContext
    {
        public SistemaFacturacionDbContext(DbContextOptions<SistemaFacturacionDbContext> options ) 
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
