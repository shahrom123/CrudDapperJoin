using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CategoryController:ControllerBase
    {
        private CategoryService _categoryService;  


        public CategoryController()
        {
            _categoryService= new CategoryService();
        }

        [HttpGet("GetCategories")]
        public List<CategoryDto> GetCategory()
        {
            return _categoryService.GetCategories();
        }
        [HttpGet("GetById")]
        public CategoryDto GetById(int id)
        {
            return _categoryService.GetById(id);
        }
        [HttpPost("AddCategory")] 
        public CategoryDto AddCategory(CategoryDto category)
        {
            return _categoryService.AddCategory(category);  
        }

        [HttpDelete("DeleteCategory")]
        public bool DeleteCategory(int id)
        {
           return _categoryService.DeleteCategory(id);
        }

        [HttpPut("UpdateCategory")]
        public CategoryDto UpdateCategory(CategoryDto category)
        {
            return _categoryService.UpdateCategory(category); 
        }

    }
}
