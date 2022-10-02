using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
    }
}
