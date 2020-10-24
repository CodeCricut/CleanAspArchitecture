using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Commands.CreateTodo
{
	public class CreateTodoRequestValidator : AbstractValidator<CreateTodoCommand>
	{
		// Validation rules should be defined in the constructor
		public CreateTodoRequestValidator()
		{
			RuleFor(createReq => createReq.Todo).NotNull();
			RuleFor(createReq => createReq.Todo.Title).NotEmpty();
			RuleFor(createReq => createReq.Todo.Text).NotEmpty();
		}
	}
}
