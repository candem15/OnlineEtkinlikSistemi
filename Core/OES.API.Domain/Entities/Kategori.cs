using OES.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }
        public ICollection<Etkinlik>? Etkinlikler { get; set; }
        [NotMapped]
        public override DateTime GuncellenmeTarihi { get => base.GuncellenmeTarihi; set => base.GuncellenmeTarihi = value; }
        [NotMapped]
        public override DateTime OlusturulmaTarihi { get => base.OlusturulmaTarihi; set => base.OlusturulmaTarihi = value; }
    }
}
