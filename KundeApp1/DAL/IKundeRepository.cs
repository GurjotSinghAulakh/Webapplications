using System;
using KundeApp1.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KundeApp1.DAL
{
    public interface IKundeRepository
    {
        Task<bool> Lagre(Kunde innKunde);
        Task<List<Kunde>> HentAlle();
        Task<bool> Slett(int id);
        Task<Kunde> HentEn(int id);
        Task<bool> Endre(Kunde endreKunde);

    }
}

