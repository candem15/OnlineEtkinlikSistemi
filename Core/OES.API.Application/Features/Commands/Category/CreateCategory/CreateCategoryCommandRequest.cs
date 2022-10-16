using MediatR;

namespace OES.API.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
    }
}
