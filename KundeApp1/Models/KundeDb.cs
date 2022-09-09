using System;
using Microsoft.EntityFrameworkCore;
namespace KundeApp1.Models
{
    public class KundeDb : DbContext
    {
        public KundeDb(DbContextOptions<KundeDb> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }
    }
}
