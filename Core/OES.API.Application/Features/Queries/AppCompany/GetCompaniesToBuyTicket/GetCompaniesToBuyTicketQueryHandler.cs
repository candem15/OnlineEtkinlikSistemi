using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.AppCompany.GetCompaniesToBuyTicket
{
    public class GetCompaniesToBuyTicketQueryHandler : IRequestHandler<GetCompaniesToBuyTicketQueryRequest, GetCompaniesToBuyTicketQueryResponse>
    {
        private readonly ICompanyService _companyService;

        public GetCompaniesToBuyTicketQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<GetCompaniesToBuyTicketQueryResponse> Handle(GetCompaniesToBuyTicketQueryRequest request, CancellationToken cancellationToken)
        {
            GetCompaniesToBuyTicketQueryResponse response = await _companyService.GetCompaniesToBuyTicketAsync(request);

            return response;
        }
    }
}