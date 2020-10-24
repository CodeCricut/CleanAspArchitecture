using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		ITodoRepository Todos { get; }
		bool SaveChanges();
	}
}
