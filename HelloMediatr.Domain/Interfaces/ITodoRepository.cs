using HelloMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Domain.Interfaces
{
	public interface ITodoRepository : IEntityRepository<Todo>
	{
		bool Complete(Guid id);
	}
}
