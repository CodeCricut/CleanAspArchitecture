using HelloMediatr.Application.Common.Exceptions;
using HelloMediatr.Application.Common.Requests;
using HelloMediatr.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Commands.CompleteTodo
{
	public class CompleteTodoCommand : IRequest<bool>
	{
		public CompleteTodoCommand(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}

	public class CompleteTodoCommandHandler : DatabaseRequestHandler<CompleteTodoCommand, bool>
	{
		public CompleteTodoCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override Task<bool> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
		{
			using (UnitOfWork)
			{
				var todo = UnitOfWork.Todos.Get(request.Id);

				if (todo == null) throw new NotFoundException();

				var successful = UnitOfWork.Todos.Complete(request.Id);

				UnitOfWork.SaveChanges();

				return Task.FromResult(successful);
			}
		}
	}
}
