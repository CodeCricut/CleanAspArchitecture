using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMediatr.Domain.Common
{
	public abstract class DomainEntity
	{
		public Guid Id { get; set; }
	}
}
