using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> Lagre(Kunde innKunde)
        {
            try
            {
                _kundeDB.Kunder.Add(innKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }




        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = await _kundeDB.Kunder.ToListAsync(); // hent hele tabellen
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Kunde enKunde = await _kundeDB.Kunder.FindAsync(id);
                _kundeDB.Remove(enKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<Kunde> HentEn(int id)
        {
            try
            {
                Kunde enKunde = await _kundeDB.Kunder.FindAsync(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            try
            {
                Kunde enKunde = await _kundeDB.Kunder.FindAsync(endreKunde.Id);
                enKunde.Navn = endreKunde.Navn;
                enKunde.Adresse = endreKunde.Adresse;
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

