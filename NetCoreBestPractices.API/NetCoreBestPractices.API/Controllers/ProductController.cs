﻿using System;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var insertedProduct = await _productService.AddAsync(_mapper.Map<Product>(product));

            return Created(String.Empty, _mapper.Map<ProductDto>(insertedProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto product)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(product));

            return NoContent();//204 dönecek. Update işlerinden sonra herhangi bir obje dönmemeliyiz. Aksi takdirde client-server arası data trafiği artmış olacak.
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var removedCategory = _productService.GetByIdAsync(id).Result;

            _productService.Remove(removedCategory);

            return NoContent();
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
    }
}