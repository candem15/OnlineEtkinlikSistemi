using OES.API.Application.Dtos.Category;

namespace OES.API.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public List<GetAllCategoriesResponse> Categories { get; set; }
    }
}