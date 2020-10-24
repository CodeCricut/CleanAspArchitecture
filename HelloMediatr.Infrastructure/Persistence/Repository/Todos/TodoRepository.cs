using HelloMediatr.Application.Common.Exceptions;
using HelloMediatr.Domain.Entities;
using HelloMediatr.Domain.Interfaces;
using HelloMediatr.Infrastructure.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace HelloMediatr.Infrastructure.Persistence.Repository.Todos
{
	public class TodoRepository : EntityRepository<Todo>, ITodoRepository
	{
		public TodoRepository(DbContext context) : base(context)
		{
		}

		public bool Complete(Guid id)
		{
			var todo = Get(id);
			if (todo == null) throw new NotFoundException();

			todo.Completed = !todo.Completed;
			return todo.Completed;
		}
	}
}
