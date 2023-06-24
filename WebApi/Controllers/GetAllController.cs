using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class GetAllController
    {
        private GetAllService _getAllService;

        public GetAllController()
        {
            _getAllService= new GetAllService();
        }

        [HttpGet("GetCategoryWithNumQuote")]
        public List<CategorieswithQouteDto> GetCategoryWithNumQuote()
        {
            return _getAllService.GetCategoriesNumQuote();
        }
        [HttpGet("Get")]
        public List<CategoryQuoteDto> GetCategoryQuote()
        {
            return _getAllService.GetCategoriesQuote(); 
        }
    }
}
