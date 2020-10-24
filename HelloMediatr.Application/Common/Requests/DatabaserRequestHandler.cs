using HelloMediatr.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Common.Requests
{
	public abstract class DatabaseRequestHandler<TRequest, TReturn> : IRequestHandler<TRequest, TReturn>
		where TRequest : IRequest<TReturn>
	{
		public DatabaseRequestHandler(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		protected IUnitOfWork UnitOfWork { get; }

		public abstract Task<TReturn> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
