using HelloMediatr.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Repositories
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> Get();
		Todo Get(Guid id);
		Guid Create(Todo todo);
		bool Remove(Guid id);
		bool Complete(Guid id);
	}
}
