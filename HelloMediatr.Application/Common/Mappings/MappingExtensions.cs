using AutoMapper;
using AutoMapper.QueryableExtensions;
using HelloMediatr.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMediatr.Application.Common.Mappings
{
	public static class MappingExtensions
	{
		public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, PagingParams pagingParams)
			=> PaginatedList<TDestination>.CreateAsync(queryable, pagingParams.PageNumber, pagingParams.PageSize);

		public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
			=> Task.FromResult(queryable.ProjectTo<TDestination>(configuration).ToList());
	}
}
