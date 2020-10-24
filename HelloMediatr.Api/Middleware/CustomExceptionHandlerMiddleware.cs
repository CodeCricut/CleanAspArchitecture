﻿using FluentValidation;
using HelloMediatr.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Middleware
{
	public class CustomExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public CustomExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
				throw;
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var code = HttpStatusCode.InternalServerError;

			var result = string.Empty;

			switch (ex)
			{
				case ValidationException validationException:
					code = HttpStatusCode.BadRequest;
					result = JsonConvert.SerializeObject(validationException.Errors);
					break;
				case NotFoundException _:
					code = HttpStatusCode.NotFound;
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			if (result == string.Empty)
			{
				result = JsonConvert.SerializeObject(new { error = ex.Message });
			}

			return context.Response.WriteAsync(result);
		}
	}
}
