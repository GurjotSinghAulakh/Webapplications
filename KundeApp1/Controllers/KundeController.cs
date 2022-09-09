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

        private readonly KundeContekst _kundeDB; // Vanlig å ha understrek foran private variabler i C#

        public KundeController (KundeContekst kundeDb)
        {
            _kundeDB = kundeDb;
        }

        public async Task<bool> Lagre(Kunde innKunde)
        {
            try {
                var nyKundeRad = new Kunder();
                nyKundeRad.Fornavn = innKunde.Fornavn;
                nyKundeRad.Etternavn = innKunde.Etternavn;
                nyKundeRad.Adresse = innKunde.Adresse;

                var sjekkPoststed = _kundeDB.Poststeder.Find(innKunde.Postnr);
                if (sjekkPoststed == null)
                {
                    var nyPoststedsRad = new Poststeder();
                    nyPoststedsRad.Postnr = innKunde.Postnr;
                    nyPoststedsRad.Poststed = innKunde.Poststed;
                    nyKundeRad.Poststed = nyPoststedsRad;
                }
                else
                {
                    nyKundeRad.Poststed = sjekkPoststed;
                }

                _kundeDB.Add(nyKundeRad);
                await _kundeDB.SaveChangesAsync();
                return true;

                /*
                _kundeDB.Kunder.Add(innKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
                */
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
                List<Kunde> alleKunder = await _kundeDB.Kunder.Select(k => new Kunde
                {
                    Id = k.Id,
                    Fornavn = k.Fornavn,
                    Etternavn = k.Etternavn,
                    Adresse = k.Adresse,
                    Postnr = k.Poststed.Postnr,
                    Poststed = k.Poststed.Poststed

                }).ToListAsync();

                return alleKunder;
                /*
                List<Kunde> alleKundene = await _kundeDB.Kunder.ToListAsync(); // hent hele tabellen
                return alleKundene;
                */
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
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);
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
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);
                var hentetKunde = new Kunde()
                {
                    Id = enKunde.Id,
                    Fornavn = enKunde.Fornavn,
                    Etternavn = enKunde.Etternavn,
                    Adresse = enKunde.Adresse,
                    Postnr = enKunde.Poststed.Postnr,
                    Poststed = enKunde.Poststed.Poststed
                };
                return hentetKunde;
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
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(endreKunde.Id);

                if (enKunde.Poststed.Postnr != endreKunde.Postnr)
                {
                    var sjekkPoststed = _kundeDB.Poststeder.Find(endreKunde.Postnr);
                    if (sjekkPoststed == null)
                    {
                        var nyPoststedsRad = new Poststeder();
                        nyPoststedsRad.Postnr = endreKunde.Postnr;
                        nyPoststedsRad.Poststed = endreKunde.Poststed;
                        enKunde.Poststed = nyPoststedsRad;
                    }
                    else
                    {
                        enKunde.Poststed = sjekkPoststed;
                    }
                }

                enKunde.Fornavn = endreKunde.Fornavn;
                enKunde.Etternavn = endreKunde.Etternavn;
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

