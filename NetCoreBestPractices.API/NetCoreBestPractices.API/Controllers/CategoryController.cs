using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreBestPractices.API.DTO;
using NetCoreBestPractices.Core;
using NetCoreBestPractices.Core.Models;
using NetCoreBestPractices.Core.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto category)
        {
            var insertedCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));

            return Created(String.Empty, _mapper.Map<CategoryDto>(insertedCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto category)
        {
            var updatedCategory = _categoryService.Update(_mapper.Map<Category>(category));

            return NoContent();//204 dönecek. Update işlerinden sonra herhangi bir obje dönmemeliyiz. Aksi takdirde client-server arası data trafiği artmış olacak.
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var removedCategory = _categoryService.GetByIdAsync(id).Result;

            _categoryService.Remove(removedCategory);

            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(long id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CateegoryWithProductDto>(category));
        }
    }
}
