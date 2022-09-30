using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Repositories;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtkinlikController : ControllerBase
    {
        private readonly IMediator _mediatR;

        private readonly IEtkinlikReadRepository _etkinlikReadRepository;
        private readonly IEtkinlikWriteRepository _etkinlikWriteRepository;
        public EtkinlikController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
    }
}
