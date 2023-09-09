using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _DbContext;
        private readonly SubjectDbContext _SubjectDbContext;

        public StudentController(StudentContext brandContext, SubjectDbContext subjectDbContext)
        {
            _DbContext = brandContext;
            _SubjectDbContext = subjectDbContext;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<ActionResult<Student>> GetAllStudet()
        {
            return Ok(_DbContext.Students.ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (_DbContext.Students == null)
            {
                return NotFound();
            }

            var brand = await _DbContext.Students.FindAsync(id);
        
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student brand)
        {
            _DbContext.Students.Add(brand);
            await _DbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new {id = brand.Id}, brand);
        }

        [HttpPut]
        public async Task<ActionResult> PutStudent(int id, Student brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _DbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!BrandAvailable(id))
                    return NotFound();
                else
                    throw;
            }
            return Ok();
        }
        private bool BrandAvailable(int id)
        {
            return (_DbContext.Students?.Any(b => b.Id == id)).GetValueOrDefault();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>DeleteStudent(int id)
        {
            if(_DbContext.Students == null)
                return NotFound();

            var brand = await _DbContext.Students.FindAsync(id);

            if(brand == null)
                return NotFound();

            _DbContext.Students.Remove(brand);

            await _DbContext.SaveChangesAsync();
            return Ok();
        }


        //Subject Controller


        [HttpGet("and Subject")]
        

        public async Task<ActionResult<SubjectDto>> GetSubjectAndStudents(int id)
        {
            var subject = await _SubjectDbContext.Subjects.FirstAsync(s => s.Id == id);
            var student = await _DbContext.Students.Where(s => s.SubjectId == subject.Id).ToListAsync();

            var result = new SubjectDto(subject.Id, subject.SubjectName, student);

            return Ok(result);
        }

        [HttpGet("All Subject")]
        public async Task<ActionResult<SubjectDto>> GetAllSubject()
        {
            return Ok(_SubjectDbContext.Subjects.ToList());
        }

        
    }
}
