using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TablePractis.Server.Data;
using TablePractis.Shared;

namespace TablePractis.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly DataContext _context;
		public StudentController(DataContext context)
		{
			_context = context;
		}
		public static List<Student> StudentO = new List<Student>();
		[HttpGet("GetStudents")]
		public async Task<ActionResult<List<Student>>> GetStudents()
		{
			var students = await _context.Students.ToListAsync();
			return Ok(students);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetSingleStudent(int id)
		{
			var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
			if(student == null)
			{
				return NotFound("Sorry, there is nothing");
			}
			return Ok(student);
		}
		[HttpPost("CreateStudent")]
		public async Task<ActionResult<bool>> CreateStudent(Student student)
		{
			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();
			return Ok(true);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteStudent(int Id)
		{
			var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == Id);
			if(student == null)
			{
				return NotFound("there is nothing");
			}
			else
			{
				_context.Students.Remove(student);
				await _context.SaveChangesAsync();
				return Ok();
			}
		}
	}
}