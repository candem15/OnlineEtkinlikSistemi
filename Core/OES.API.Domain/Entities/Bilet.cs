using OES.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Bilet : BaseEntity

    {
        public Guid EtkinlikId { get; set; }
        public double BiletUcreti { get; set; }
        public Etkinlik Etkinlik { get; set; }
    }
}
