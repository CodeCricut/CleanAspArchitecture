using HelloMediatr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Domain.Entities
{
	public class Todo : DomainEntity
	{
		public string Title { get; set; }
		public string Text { get; set; }
		public bool Completed { get; set; }
	}
}
