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
				options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
			});
			builder.Services
				.AddControllers()
				.AddOData(options =>
				{
					options.AddRouteComponents("odata", EdmBuilder.Build());
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
			app.Run();
		}
	}
}