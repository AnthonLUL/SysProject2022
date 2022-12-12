using AbsenseApi.DBContext;
using AbsenseApi.Managers;
using Microsoft.AspNetCore.Mvc;
using StudentLibrary;

namespace AbsenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenseApiController : ControllerBase
    {
        
        private readonly IAbsenseApiManager _manager;
        public AbsenseApiController(StudentContext context)
        {
            _manager = new AbsenseApiManagerDB(context);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IEnumerable<Student> Get(string? name)
        {
            return _manager.GetAllStudents(name);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{nFCId}")]
        public ActionResult<Student> Get(long nFCId)
        {
            Student student = _manager.GetByNFCId(nFCId);
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
            return Created("/" + students.Id ,students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{nFCId}")]
        public ActionResult Put(long nFCId) // hvis du skal returner en type så det actionResult<Type> ex. ActionResult<Student>
        {
            Student student = _manager.Update(nFCId);
            if (student == null) return NotFound("There is no student with the given Id");
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(int id)
        {
            Student student = _manager.Delete(id);
            if (student == null) return NotFound("There is no student with that id");
            return Ok(student);
            

        }




    }
}
