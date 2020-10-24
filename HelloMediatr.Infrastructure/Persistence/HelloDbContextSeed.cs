using HelloMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMediatr.Infrastructure.Persistence
{
	public static class HelloDbContextSeed
	{
        public static async Task SeedSampleDataAsync(HelloDbContext context)
        {
            // Seed, if necessary
            if (!context.Todos.Any())
            {
                var todos = new List<Todo>
                {
                    new Todo { Id = Guid.NewGuid(), Title = "Title 1", Text = "Todo 1", Completed = false },
                    new Todo { Id = Guid.NewGuid(), Title = "Title 2", Text = "Todo 2", Completed = true }
                };

                context.Todos.AddRange(todos);

                await context.SaveChangesAsync();
            }
        }
    }
}
