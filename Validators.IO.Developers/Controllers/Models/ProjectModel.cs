using System.Collections.Generic;
using Validators.IO.Developers.Database.Entities;

namespace Validators.IO.Developers.Controllers
{
	public class ProjectModel
	{
		public Project Project { get; set; }
		public AppSettings Settings { get; internal set; }
	}
}