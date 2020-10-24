using FluentValidation;
using HelloMediatr.Api.Models.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Mediatr.Common
{
	public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var validationFailures = _validators
				.Select(validator => validator.Validate(request))
				.SelectMany(validationResult => validationResult.Errors)
				.Where(validationFailure => validationFailure != null)
				.ToList();

			if (validationFailures.Any())
			{
				var error = string.Join("\r\n", validationFailures);
				throw new InvalidRequestException(error, request);
			}

			return next();
		}
	}
}
