using HelloMediatr.Application.Common.Exceptions;
using HelloMediatr.Application.Common.Requests;
using HelloMediatr.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Commands.RemoveTodo
{
	public class RemoveTodoCommand : IRequest<bool>
	{
		public RemoveTodoCommand(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}

	public class RemoveTodoCommandHandler : DatabaseRequestHandler<RemoveTodoCommand, bool>
	{
		public RemoveTodoCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override Task<bool> Handle(RemoveTodoCommand request, CancellationToken cancellationToken)
		{
			using (UnitOfWork)
			{
				var todo = UnitOfWork.Todos.Get(request.Id);
				if (todo == null) throw new NotFoundException();

				var successful = UnitOfWork.Todos.Remove(request.Id);
				UnitOfWork.SaveChanges();
				return Task.FromResult(successful);
			}
		}
	}
}
