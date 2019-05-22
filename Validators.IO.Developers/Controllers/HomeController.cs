using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Validators.IO.Developers.Database;
using Validators.IO.Developers.Database.Entities;
using Validators.IO.Developers.Utilities;

namespace Validators.IO.Developers.Controllers
{
	public class HomeController : BaseController
	{
		private readonly AppSettings settings;

		public HomeController(AppDbContext dbContext, UserManager<User> userManager, IOptions<AppSettings> settings) : base(dbContext, userManager)
		{
			this.settings = settings.Value;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			var blockchains = dbContext.Blockchains.ToList();

			return View(blockchains);
		}
		[AllowAnonymous]
		public IActionResult Privacy()
		{
			return View();
		}
	}
}
