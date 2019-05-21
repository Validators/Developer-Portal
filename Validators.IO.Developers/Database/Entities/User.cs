using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Validators.IO.Developers.Database.Entities
{
	public class User : IdentityUser<Guid>
	{
		public string CustomTag { get; set; }
	}
}
