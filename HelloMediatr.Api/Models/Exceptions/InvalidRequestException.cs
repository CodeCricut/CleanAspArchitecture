using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Models.Exceptions
{
	public class InvalidRequestException : Exception
	{

		public InvalidRequestException(string message, object request) : base(message)
		{
			Request = request;
		}

		public object Request { get; }
	}
}
