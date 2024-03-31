using Microsoft.AspNetCore.Mvc;

namespace DarkWorldChar.Backend.Helpers
{
	internal static class ActionResultHelper
	{
		public static ObjectResult GetResult(int statusCode, object? value = null)
		{
			var result = new ObjectResult(value)
			{
				StatusCode = statusCode,
			};
			return result;
		}
	}
}
