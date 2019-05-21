using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Validators.IO.Developers.Database;
using Validators.IO.Developers.Database.Entities;
using Validators.IO.Developers.Models;

namespace Validators.IO.Developers.Controllers
{
	public class BaseController : Controller
	{
		internal readonly AppDbContext dbContext;
		internal readonly UserManager<User> userManager;

		public BaseController(AppDbContext dbContext, UserManager<User> userManager)
		{
			this.dbContext = dbContext;
			this.userManager = userManager;
		}

		public User CurrentUser
		{
			get
			{
				var user = userManager.GetUserAsync(HttpContext.User).Result;

				return user;
			}
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
