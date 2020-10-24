using HelloMediatr.Domain.Common;
using HelloMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMediatr.Domain.Interfaces
{
	public interface IEntityRepository<TEntity>
		where TEntity : DomainEntity
	{
		// Note: this doesn't contain all methods that you might expect in a generic repository
		IQueryable<TEntity> Get();
		TEntity Get(Guid id);
		Guid Create(TEntity todo);
		bool Remove(Guid id);
	}
}
