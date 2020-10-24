using HelloMediatr.Api.Models;
using HelloMediatr.Api.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Mediatr.Todos.Queries
{
	public class GetTodoQuery : IRequest<Todo>
	{
		public GetTodoQuery(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}

	public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Todo>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodoQueryHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public Task<Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_todoRepository.Get(request.Id));
		}
	}
}
