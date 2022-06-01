using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataTest.Models;

namespace ODataTest
{
	public static class EdmBuilder
	{
		public static IEdmModel Build()
		{
			var builder = new ODataConventionModelBuilder();
			builder.EntitySet<User>("Users");
			return builder.GetEdmModel();
		}
	}
}
