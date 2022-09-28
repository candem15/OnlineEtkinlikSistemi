using OES.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Etkinlik : BaseEntity
    {
        public string EtkinlikAdi { get; set; }
        public Sehir Sehir { get; set; }
        public Kontenjan Kontenjan { get; set; }
        public Bilet ?Bilet { get; set; }
        public string Adres { get; set; }
        public DateTime SonBasvuruTarihi { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public string Aciklama { get; set; }
        public bool EtkinlikOnayi { get; set; }
        public Kategori Kategori { get; set; }
    }
}
