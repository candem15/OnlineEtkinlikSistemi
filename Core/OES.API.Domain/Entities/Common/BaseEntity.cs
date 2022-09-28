using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        virtual public DateTime OlusturulmaTarihi { get; set; }
        virtual public DateTime GuncellenmeTarihi { get; set; }
    }
}
