using Microsoft.EntityFrameworkCore;
using ODataTest.Models;

namespace ODataTest
{
	public class TestContext : DbContext
	{
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			/* Schema */
			builder.Entity<User>().HasIndex(o => o.Username).IsUnique();

			/* Seed */
			builder.Entity<User>().HasData(new User() { UserId = 1, Username = "admin" });
		}

		public TestContext(DbContextOptions<TestContext> options) : base(options) { }
	}
}
