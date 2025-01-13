using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreBestPractices.API.DTO.Book;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Services;

namespace NetCoreBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookDto book)
        {
            var insertedBook = await _bookService.AddAsync(_mapper.Map<Book>(book));
            return Created(String.Empty, _mapper.Map<BookDto>(insertedBook));
        }

        [HttpPut]
        public IActionResult Update(BookDto book)
        {
            var updatedBook = _bookService.Update(_mapper.Map<Book>(book));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var removedBook = _bookService.GetByIdAsync(id).Result;
            _bookService.Remove(removedBook);
            return NoContent();
        }
    }
}
