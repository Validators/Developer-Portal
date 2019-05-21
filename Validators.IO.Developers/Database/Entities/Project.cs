using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Validators.IO.Developers.Database.Entities
{
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Guid ApiKey { get; set; }

		public string ApiSecret { get; set; }


		public virtual Blockchain Blockchain { get; set; }

		public DateTime CreatedUtc { get; set; }

		public bool IsDeleted { get; set; }

		public Guid UserId { get; set; }
	}
}
