using System;
namespace KundeApp1.Models
{
    public class Kunde
    {
        public int Id { get; set; }  // med Id som variabel blir dette en autoincrement i databasen (pr. default).
        public string Navn { get; set; }
        public string Adresse { get; set; }
    }
}
