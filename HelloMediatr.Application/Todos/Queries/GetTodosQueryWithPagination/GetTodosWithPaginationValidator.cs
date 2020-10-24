using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Application.Todos.Queries.GetTodosQueryWithPagination
{
	public class GetTodosWithPaginationValidator : AbstractValidator<GetTodosWithPaginationQuery>
	{
		public GetTodosWithPaginationValidator()
		{
			RuleFor(request => request.PagingParams).NotNull();
			RuleFor(request => request.PagingParams.PageNumber).GreaterThan(0);
			RuleFor(request => request.PagingParams.PageSize).GreaterThan(0).LessThan(100);
		}
	}
}
