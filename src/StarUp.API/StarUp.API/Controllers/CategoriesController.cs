using StartUp.Data.Exceptions;
using StartUp.Data.Model;
using StartUp.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StarUp.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_categoryService.Queryable());
        }

        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.GetById(id);
            if(category == null)
                throw new DataNotFoundException($"Could not find Category with id {id}");
            return Ok(category);
        }
    }
}