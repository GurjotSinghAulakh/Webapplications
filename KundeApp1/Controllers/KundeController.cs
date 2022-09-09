using System;
using System.Collections.Generic;
using System.Linq;
using KundeApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KundeApp1.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {

        private readonly KundeDb _kundeDB; // Vanlig å ha understrek foran private variabler i C#

        public KundeController (KundeDb kundeDb)
        {
            _kundeDB = kundeDb;
        }

        public bool Lagre(Kunde innKunde)
        {
            try
            {
                _kundeDB.Kunder.Add(innKunde);
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }




        public List<Kunde> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = _kundeDB.Kunder.ToList(); // hent hele tabellen
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public bool Slett(int id)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(id);
                _kundeDB.Remove(enKunde);
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Kunde HentEn(int id)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

        public bool Endre(Kunde endreKunde)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(endreKunde.Id);
                enKunde.Navn = endreKunde.Navn;
                enKunde.Adresse = endreKunde.Adresse;
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

