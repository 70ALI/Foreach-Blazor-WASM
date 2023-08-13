using Microsoft.EntityFrameworkCore;
using TablePractis.Shared;
using TablePractis.Server.Data;

namespace TablePractis.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Student>().HasData(
							new Student
							{
								Id = 1,
								Name = "Ali",
								FirstName = "Ali",
								LastName = "Abdullah",
								Email = "ali@alimail"

							},
							new Student
							{
								Id = 2,
								Name = "Ahmad",
								FirstName = "Ahmad",
								LastName = "Aoud",
								Email = "ahmad@aoudmail"
							}
			);
		}

		public DbSet<Student> Students { get; set; }
	}
}
