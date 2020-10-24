using HelloMediatr.Api.Mediatr.Todos.Commands;
using HelloMediatr.Api.Mediatr.Todos.Queries;
using HelloMediatr.Api.Models;
using HelloMediatr.Api.Models.Exceptions;
using HelloMediatr.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
		public async Task<IEnumerable<Todo>> GetAsync() =>
			await Mediator.Send(new GetTodosQuery());

		[HttpPatch("{id}")]
		public async Task<bool> CompleteAsync(Guid id) =>
			await Mediator.Send(new CompleteTodoCommand(id));

		[HttpDelete("{id}")]
		public async Task<bool> DeleteAsync(Guid id) =>
			await Mediator.Send(new RemoveTodoCommand(id));

	}
}
