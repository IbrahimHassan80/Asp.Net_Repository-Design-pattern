using design_pattern.Interfaces;
using design_pattern.Model;
using Microsoft.AspNetCore.Mvc;

namespace design_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authorcontroller: ControllerBase
    {
        private readonly IBaseRepository<Author> _authorsRepository;
        public Authorcontroller(IBaseRepository<Author> authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }
        [HttpGet]
        public IActionResult GetById(){
            return Ok(_authorsRepository.GetById(2));
        }

        [HttpGet("GetByIdAsync")]
        public async  Task<IActionResult> GetByIdAsync(){
            return Ok(await _authorsRepository.GetByIdAsync(1));
        }
    
        [HttpGet("GetAll")]
        public IActionResult GetAll(){
            return Ok(_authorsRepository.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_authorsRepository.Find(b => b.Name == "ibrahim"));
        }

    }
}