using TablePractis.Shared;

namespace TablePractis.Client.Services
{
	public interface IStudentService
	{
		List<Student> Students { get; set; }
		Task GetStudents();
		Task<Student> GetStudent(int Id);
		Task<string> CreateStudent(Student student);
		Task UpdateStudent(Student student);
		Task DeleteStudent(int Id);
	}
}