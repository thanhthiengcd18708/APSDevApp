using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace APSDevApp.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
				: base("DefaultConnection", throwIfV1Schema: false)
		{
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		public DbSet<Trainee> Trainees { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}