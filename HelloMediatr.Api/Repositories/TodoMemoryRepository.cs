using HelloMediatr.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Repositories
{
	public class TodoMemoryRepository : ITodoRepository
	{
		private static List<Todo> todos = new List<Todo>
		{
			new Todo { Id = Guid.NewGuid(), Title = "Title 1", Text = "Todo 1", Completed = false },
			new Todo { Id = Guid.NewGuid(), Title = "Title 2", Text = "Todo 2", Completed = true }
		};

		public bool Complete(Guid id)
		{
			var todo = todos.FirstOrDefault(t => t.Id == id);
			if (todo == null) return false;

			todo.Completed = true;
			return true;
		}

		public Guid Create(Todo todo)
		{
			var guid = Guid.NewGuid();
			todo.Id = guid;
			todos.Add(todo);

			return guid;
		}

		public IEnumerable<Todo> Get()
		{
			return todos;
		}

		public Todo Get(Guid id)
		{
			return todos.FirstOrDefault(t => t.Id == id);
		}

		public bool Remove(Guid id)
		{
			var todo = todos.FirstOrDefault(t => t.Id == id);
			if (todo == null) return false;

			todos.Remove(todo);
			return true;
		}
	}
}
