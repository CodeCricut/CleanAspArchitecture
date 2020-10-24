using HelloMediatr.Application.Common.Exceptions;
using HelloMediatr.Domain.Common;
using HelloMediatr.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelloMediatr.Infrastructure.Persistence.Repository.Common
{
	public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
		where TEntity : DomainEntity
	{
		protected DbSet<TEntity> _entities;

		public EntityRepository(DbContext context)
		{
			_entities = context.Set<TEntity>();
		}

		public Guid Create(TEntity entity)
		{
			var guid = Guid.NewGuid();
			entity.Id = guid;
			_entities.Add(entity);

			return guid;
		}

		public IQueryable<TEntity> Get()
		{
			return _entities.AsQueryable();
		}

		public TEntity Get(Guid id)
		{
			return _entities.FirstOrDefault(entity => entity.Id == id);
		}

		public bool Remove(Guid id)
		{
			var entity = Get(id);
			if (entity == null) throw new NotFoundException();

			_entities.Remove(entity);
			return true;
		}
	}
}
