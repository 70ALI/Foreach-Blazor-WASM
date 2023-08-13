using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using TablePractis.Shared;
using Newtonsoft.Json;
using System.Text;

namespace TablePractis.Client.Services
{
	public class StudentService : IStudentService
	{
		private readonly HttpClient _httpClient;
		public StudentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public List<Student> Students { get; set; } = new List<Student>();
		// here Error
		public async Task<string> CreateStudent(Student student)
		{
			var result = await _httpClient.PostAsJsonAsync("api/student/CreateStudent", student);
			var respnse = result.Content.ReadAsStringAsync();
			return "";
		}
		public async Task DeleteStudent(int Id)
		{
			 await _httpClient.DeleteAsync($"api/student/{Id}");
		}
		public async Task<Student?> GetStudent(int Id)
		{
			var result = await _httpClient.GetFromJsonAsync<Student>($"api/student/{Id}");
			if (result != null)
			{
				return result;
			}
			else
			{
				return null;
			}
		}
		public async Task GetStudents()
		{
			var result = await _httpClient.GetFromJsonAsync<List<Student>>("api/student/GetStudents");
			if (result != null)
			{ // here issue
				Students = result;
			}
		}
		public Task UpdateStudent(Student student)
		{
			throw new NotImplementedException();
		}
	}
}