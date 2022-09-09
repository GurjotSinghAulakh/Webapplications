using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace KundeApp1.Models
{
    public class Kunder
    {
        public int Id { get; set; }  
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }

        virtual public Poststeder Poststed { get; set; }
    }

    public class Poststeder
    {

        [Key] // Automatisk nøkkel ved å sette opp dekratør [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.None)] // For å sikre at vi ikke får autoincrememt på den 
        public string Postnr { get; set; }
        public string Poststed { get; set; }
    }


    public class KundeContekst : DbContext
    {
        public KundeContekst(DbContextOptions<KundeContekst> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
