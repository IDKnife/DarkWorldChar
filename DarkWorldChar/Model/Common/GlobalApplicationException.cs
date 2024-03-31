using System;

namespace DarkWorldChar.Model.Common
{
	public class GlobalApplicationException : Exception
	{
		public int StatusCode { get; set; }

		public GlobalApplicationException(string message, int statusCode, Exception? innerException = null) : base(message, innerException)
		{
			StatusCode = statusCode;
		}
	}
}
