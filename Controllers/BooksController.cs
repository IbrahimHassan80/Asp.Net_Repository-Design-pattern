using design_pattern.Consts;
using design_pattern.Interfaces;
using design_pattern.Model;
using Microsoft.AspNetCore.Mvc;
namespace design_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        private readonly IBaseRepository<Book> _booksRepository;
        public BooksController(IBaseRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_booksRepository.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(){
            return Ok(_booksRepository.GetById(2));
        }

        [HttpGet("GetByIdAsync")]
        public async  Task<IActionResult> GetByIdAsync(){
            return Ok(await _booksRepository.GetByIdAsync(2));
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle()
        {
            return Ok(_booksRepository.Find(b => b.Title == "new book"));
        }

        [HttpGet("FindWithRelation")]
        public IActionResult FindWithRelation()
        {
            return Ok(_booksRepository.FindWithRelation(b => b.Title == "new book", new[] {"author"}));
        }

        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            return Ok(_booksRepository.FindWithRelation(b => b.Title.Contains("new book"), new[] {"author"}));
        }

        [HttpGet("GetOrdred")]
        public IActionResult GetOrderd()
        {
            return Ok(_booksRepository.FindAll(b => b.Title.Contains("book"), null , null, b => b.Id, OrderBy.Descending));
        }
    
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            return Ok(_booksRepository.Add(new Book{Title = "test", AuthorId = 1}));
        }

        [HttpPut("update")]
        public IActionResult update()
        {
            return Ok(_booksRepository.update(new Book{Id = 5,Title = "update", AuthorId = 3}));
        }
        
    }
}