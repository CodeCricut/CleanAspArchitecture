using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMediatr.Api.Models
{
	public class Todo
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public bool Completed { get; set; }
	}
}
