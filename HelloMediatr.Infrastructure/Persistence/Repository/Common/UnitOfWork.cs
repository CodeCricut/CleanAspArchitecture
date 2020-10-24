using Microsoft.EntityFrameworkCore;

namespace HelloMediatr.Domain.Interfaces
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly DbContext _context;

		public ITodoRepository Todos { get; private set; }

		public UnitOfWork(DbContext context, ITodoRepository todoRepository)
		{
			_context = context;
			Todos = todoRepository;
		}


		public virtual bool SaveChanges()
		{
			return _context.SaveChanges() > 0;
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
