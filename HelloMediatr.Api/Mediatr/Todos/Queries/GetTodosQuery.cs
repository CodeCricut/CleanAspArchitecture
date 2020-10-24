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
	public class GetTodosQuery : IRequest<IEnumerable<Todo>>
	{
	}

	public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<Todo>>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodosQueryHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public Task<IEnumerable<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_todoRepository.Get());
		}
	}
}
