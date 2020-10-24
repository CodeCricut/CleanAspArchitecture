using HelloMediatr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Infrastructure.Persistence.Configurations
{
	public class TodoConfiguration : IEntityTypeConfiguration<Todo>
	{
		public void Configure(EntityTypeBuilder<Todo> builder)
		{
			builder.Property(todo => todo.Title)
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(todo => todo.Text)
				.HasMaxLength(2000)
				.IsRequired();
		}
	}
}
