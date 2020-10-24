using HelloMediatr.Application.Common.Exceptions;
using HelloMediatr.Application.Common.Requests;
using HelloMediatr.Domain.Entities;
using HelloMediatr.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Queries.GetTodo
{
	public class GetTodoQuery : IRequest<Todo>
	{
		public GetTodoQuery(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}

	public class GetTodoQueryHandler : DatabaseRequestHandler<GetTodoQuery, Todo>
	{
		public GetTodoQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override Task<Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
		{
			using (UnitOfWork)
			{
				var todo = UnitOfWork.Todos.Get(request.Id);
				if (todo == null) throw new NotFoundException();
				return Task.FromResult(todo);
			}
		}
	}
}
