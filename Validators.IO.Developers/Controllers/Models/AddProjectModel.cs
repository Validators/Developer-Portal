using System.Collections.Generic;
using Validators.IO.Developers.Database.Entities;

namespace Validators.IO.Developers.Controllers
{
	public class AddProjectModel
	{
		public List<Blockchain> Blockchains { get; set; }

		public string Name { get; set; }
		public int SelectedBlockchainId { get; set; }
	}
}