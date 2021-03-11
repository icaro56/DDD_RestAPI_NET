﻿using Microsoft.EntityFrameworkCore;
using RestAPIModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
            
            // Verifica se há as tabelas, se não existe cria elas
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
                optionBuilder.UseSqlServer(GetStringConnectionConfig());

            base.OnConfiguring(optionBuilder);
        }

        private string GetStringConnectionConfig()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Ecommerce;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connectionString;
        }
    }
}