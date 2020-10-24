using HelloMediatr.Application.Common.Models;
using HelloMediatr.Application.Todos.Commands.CompleteTodo;
using HelloMediatr.Application.Todos.Commands.CreateTodo;
using HelloMediatr.Application.Todos.Commands.RemoveTodo;
using HelloMediatr.Application.Todos.Queries.GetTodo;
using HelloMediatr.Application.Todos.Queries.GetTodosQueryWithPagination;
using HelloMediatr.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Controllers
{
	[Route("api/[controller]")]
	public class TodosController : ApiController
	{
		[HttpPost]
		public async Task<Guid> CreateAsync([FromBody] Todo todo) =>
			await Mediator.Send(new CreateTodoCommand(todo));


		[HttpGet("{id}")]
		public async Task<Todo> GetByIdAysnc(Guid id) =>
			await Mediator.Send(new GetTodoQuery(id));

		[HttpGet]
		public async Task<PaginatedList<Todo>> GetAsync([FromQuery] PagingParams pagingParams) =>
			await Mediator.Send(new GetTodosWithPaginationQuery(pagingParams));

		[HttpPatch("{id}")]
		public async Task<bool> CompleteAsync(Guid id) =>
			await Mediator.Send(new CompleteTodoCommand(id));

		[HttpDelete("{id}")]
		public async Task<bool> DeleteAsync(Guid id) =>
			await Mediator.Send(new RemoveTodoCommand(id));

	}
}
