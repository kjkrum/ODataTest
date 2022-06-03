using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

namespace ODataTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContextFactory<TestContext>(options =>
			{
				options.UseInMemoryDatabase("Test");
			});
			builder.Services
				.AddControllers()
				.AddOData(options =>
				{
					options.AddRouteComponents("odata", EdmBuilder.Build());
					options.QuerySettings.EnableCount = false;
				});
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			using(var scope = app.Services.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<TestContext>();
				db.Users.Add(new Models.User() { UserId = 1, Username = "admin" });
				db.SaveChanges();
			}
			app.Run(); 
		}
	}
}