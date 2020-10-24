using HelloMediatr.Application.Common.Requests;
using HelloMediatr.Domain.Entities;
using HelloMediatr.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Commands.CreateTodo
{
	public class CreateTodoCommand : IRequest<Guid>
	{
		public CreateTodoCommand(Todo todo)
		{
			Todo = todo;
		}

		public Todo Todo { get; }
	}

	public class CreateTodoCommandHandler : DatabaseRequestHandler<CreateTodoCommand, Guid>
	{
		public CreateTodoCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
		{
			using (UnitOfWork)
			{
				var guid = UnitOfWork.Todos.Create(request.Todo);
				UnitOfWork.SaveChanges();
				return Task.FromResult(guid);
			}
		}
	}
}
