using AbsenseApi.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLibrary;

namespace AbsenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenseApiController : ControllerBase
    {
        private readonly AbsenseApiManager _manager = new AbsenseApiManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _manager.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{name}")]
        public ActionResult<Student> Get(string name)
        {
            Student student = _manager.GetByName(name);
            if (student == null) return NotFound("lmao");
            return student;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student value)
        {
            Student students = _manager.Add(value);
            return Created("/" + students.StudentId ,students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("id")]
        public ActionResult<Student> Put(int id, [FromBody] Student value)
        {
            Student student = _manager.Update(id, value);
            if (student == null) return NotFound("There is no student with the given Id");
            return Ok(value);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id")]
        public ActionResult<Student> Delete(int id)
        {
            Student student = _manager.Delete(id);
            if (student == null) return NotFound("There is no student with that id");
            return Ok(student);
            

        }


    }
}
