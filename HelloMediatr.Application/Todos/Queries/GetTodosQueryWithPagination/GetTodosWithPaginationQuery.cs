using AutoMapper;
using HelloMediatr.Application.Common.Mappings;
using HelloMediatr.Application.Common.Models;
using HelloMediatr.Application.Common.Requests;
using HelloMediatr.Domain.Entities;
using HelloMediatr.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Todos.Queries.GetTodosQueryWithPagination
{
	public class GetTodosWithPaginationQuery : IRequest<PaginatedList<Todo>>
	{
		public GetTodosWithPaginationQuery(PagingParams pagingParams)
		{
			PagingParams = pagingParams;
		}

		public PagingParams PagingParams { get; }
	}

	public class GetTodosWithPaginationQueryHandler : DatabaseRequestHandler<GetTodosWithPaginationQuery, PaginatedList<Todo>>
	{
		public GetTodosWithPaginationQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public override async Task<PaginatedList<Todo>> Handle(GetTodosWithPaginationQuery request, CancellationToken cancellationToken)
		{
			using (UnitOfWork)
			{
				var allTodos = UnitOfWork.Todos.Get();
				return await allTodos.PaginatedListAsync(request.PagingParams);
			}
		}
	}
}
