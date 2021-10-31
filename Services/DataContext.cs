using IncidentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Incident>()
        //        .HasMany(p => p.Accounts)
        //        .WithOne(c => c.Incedent);

        //    builder.Entity<Account>()
        //        .HasMany(p => p.Contacts)
        //        .WithOne(c => c.Account);
        //}
    }
}
