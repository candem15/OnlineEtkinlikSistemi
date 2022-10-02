using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
    }
}
