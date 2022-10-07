using OES.API.Domain.Entities.Common;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void EnableLazyLoading();
    }
}
