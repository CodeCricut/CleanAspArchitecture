using HelloMediatr.Api.Models;
using HelloMediatr.Api.Repositories;
using HelloMediatr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Mediatr.Todos.Commands
{
	public class CreateTodoCommand : IRequest<Guid>
	{
		public CreateTodoCommand(Todo todo)
		{
			Todo = todo;
		}

		public Todo Todo { get; }
	}

	public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Guid>
	{
		private readonly ITodoRepository _todoRepository;

		public CreateTodoCommandHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
		{
			var guid = _todoRepository.Create(request.Todo);
			return Task.FromResult(guid);
		}
	}
}
