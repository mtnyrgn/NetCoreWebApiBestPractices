using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreBestPractices.API.DTO.Person;
using NetCoreBestPractices.API.Filters;
using NetCoreBestPractices.Core.Documents;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;

namespace NetCoreBestPractices.API.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMongoService<Person> _personService;
        private readonly IMapper _mapper;
        public PersonController(IMongoService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //throw new Exception("Tüm dataları çekerken hata meydana geldi"); //Global oarak yazılan exception handlerın bunu yakalaması ve kendi error dto modelimize uygun geri dönüş yaptı.
            var persons = await _personService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [ServiceFilter(typeof(NotFoundFilter))]//NotFoundFilter DI objesi aldığı için service filter olarak tanımlandı.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var person = await _personService.GetByIdAsync(id);

            return Ok(_mapper.Map<PersonDto>(person));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(PersonDto person)
        {
            var insertedPerson = await _personService.AddAsync(_mapper.Map<Person>(person));

            return Created(String.Empty, _mapper.Map<PersonDto>(insertedPerson));
        }

        [HttpPut]
        public IActionResult Update(PersonDto person)
        {
            var updatedPerson = _personService.Update(_mapper.Map<Person>(person));

            return NoContent();//204 dönecek. Update işlerinden sonra herhangi bir obje dönmemeliyiz. Aksi takdirde client-server arası data trafiği artmış olacak.
        }

        [ServiceFilter(typeof(NotFoundFilter))] //NotFoundFilter DI objesi aldığı için service filter olarak tanımlandı.
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            //var removedPerson = _personService.GetByIdAsync(id).Result;

            _personService.Remove(id);

            return NoContent();
        }
    }
}