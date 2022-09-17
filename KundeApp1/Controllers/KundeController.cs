using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeApp1.DAL;
using KundeApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KundeApp1.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepository _db;

        public KundeController(IKundeRepository db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Kunde innkunde)
        {
            return await _db.Lagre(innkunde);
        }

        public async Task<List<Kunde>> HentAlle()
        {
            return await _db.HentAlle();
        }

        public async Task<bool> Slett(int id)
        {
            return await _db.Slett(id);
        }

        public async Task<Kunde> HentEn(int id)
        {
            return await _db.HentEn(id);
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            return await _db.Endre(endreKunde);
        }




    }
}

