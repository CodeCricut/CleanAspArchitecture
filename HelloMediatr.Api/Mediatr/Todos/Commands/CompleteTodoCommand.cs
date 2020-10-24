using HelloMediatr.Api.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Mediatr.Todos.Commands
{
	public class CompleteTodoCommand : IRequest<bool>
	{
		public CompleteTodoCommand(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}

	public class CompleteTodoCommandHandler : IRequestHandler<CompleteTodoCommand, bool>
	{
		private readonly ITodoRepository _todoRepository;

		public CompleteTodoCommandHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public Task<bool> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
		{
			var successful = _todoRepository.Complete(request.Id);
			return Task.FromResult(successful);
		}
	}
}
