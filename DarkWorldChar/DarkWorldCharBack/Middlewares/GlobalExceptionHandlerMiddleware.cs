using System;
using System.Text.Json;
using System.Threading.Tasks;
using DarkWorldChar.Model.Common;
using Microsoft.AspNetCore.Http;

namespace DarkWorldChar.Backend.Middlewares
{
	public class GlobalExceptionHandlerMiddleware
	{
		private readonly RequestDelegate m_requestDelegate;

		public GlobalExceptionHandlerMiddleware(RequestDelegate requestDelegate)
		{
			m_requestDelegate = requestDelegate;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await m_requestDelegate(context);
			}
			catch (Exception e)
			{
				await HandleExceptionAsync(context, e);
			}
		}

		private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			int statusCode;

			if (exception is GlobalApplicationException appException)
			{
				statusCode = appException.StatusCode;
			}
			else
			{
				statusCode = StatusCodes.Status500InternalServerError;
			}

			context.Response.StatusCode = statusCode;
			context.Response.ContentType = "application/json";

			await context.Response.WriteAsync(JsonSerializer.Serialize(new GlobalExceptionDetails { Message = exception.Message, Trace = exception.StackTrace }));
		}
	}
}
