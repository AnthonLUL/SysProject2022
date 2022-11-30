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
        public IEnumerable<Students> Get()
        {
            return _manager.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{name}")]
        public ActionResult<Students> Get(string name)
        {
            Students student = _manager.GetByName(name);
            if (student == null) return NotFound("lmao");
            return student;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [HttpPost]
        public ActionResult<Students> Post([FromBody] Students value)
        {
            Students students = _manager.Add(value);
            return Created("/" + students.StudentId ,students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("id")]
        public ActionResult<Students> Put(int id, [FromBody] Students value)
        {
            Students student = _manager.Update(id, value);
            if (student == null) return NotFound("There is no student with the given Id");
            return Ok(value);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id")]
        public ActionResult<Students> Delete(int id)
        {
            Students student = _manager.Delete(id);
            if (student == null) return NotFound("There is no student with that id");
            return Ok(student);
            

        }


    }
}
