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
	public class ProjectController : BaseController
	{
		private readonly AppSettings settings;

		public ProjectController(AppDbContext dbContext, UserManager<User> userManager, IOptions<AppSettings> settings) : base(dbContext, userManager)
		{
			this.settings = settings.Value;
		}


		public IActionResult Dashboard()
		{
			var projects = dbContext.ActiveProjects.Include(p => p.Blockchain).Where(p => p.UserId == CurrentUser.Id).OrderByDescending(p => p.Id).ToList();

			return View(new DashboardModel { Projects = projects });
		}

		[Route("project/view/{projectId}")]
		public IActionResult Project(int projectId)
		{
			var model = new ProjectModel();
			var project = dbContext.ActiveProjects.Include(p => p.Blockchain).Where(p => p.Id == projectId && p.UserId == CurrentUser.Id).SingleOrDefault();

			if (project == null)
				return BadRequest("Project not found or access denied.");

			model.Project = project;
			model.Settings = settings;

			return View(model);
		}

		[Route("project/delete/{projectId}")]
		public IActionResult DeleteProject(int projectId)
		{
			var model = new ProjectModel();
			var project = dbContext.ActiveProjects.Include(p => p.Blockchain).Where(p => p.Id == projectId && p.UserId == CurrentUser.Id).SingleOrDefault();

			if (project == null)
				return BadRequest("Project not found or access denied.");

			model.Project = project;
			model.Settings = settings;

			return View(model);
		}

		[HttpPost]
		[Route("project/delete/{projectId}")]
		public IActionResult DeleteProject(ProjectModel model)
		{
			var project = dbContext.ActiveProjects.Include(p => p.Blockchain).Where(p => p.Id == model.Project.Id && p.UserId == CurrentUser.Id).SingleOrDefault();

			if (project == null)
				return BadRequest("Project not found or access denied.");

			project.IsDeleted = true;

			dbContext.Projects.Update(project);
			dbContext.SaveChanges();

			return RedirectToAction(nameof(Dashboard));
		}

		public IActionResult AddProject()
		{
			var model = new AddProjectModel();
			var blockchains = dbContext.Blockchains.ToList();

			model.Blockchains = blockchains;

			return View(model);
		}

		[HttpPost]
		public IActionResult AddProject(AddProjectModel model)
		{
			var blockchain = dbContext.Blockchains.Where(b => b.Id == model.SelectedBlockchainId).SingleOrDefault();

			if (blockchain == null)
				return BadRequest("Blockchain not found with id: " + model.SelectedBlockchainId  +".");

			var apiKey = Guid.NewGuid();
			var apiSecret = RandomKeyGenerator.GetUniqueKey(128);

			var project = new Project
			{
				Name = model.Name,
				UserId = CurrentUser.Id,
				ApiKey = apiKey,
				ApiSecret = apiSecret,
				Blockchain = blockchain,
				CreatedUtc = DateTime.UtcNow
			};

			dbContext.Projects.Add(project);
			dbContext.SaveChanges();

			return RedirectToAction(nameof(Project), new { projectId = project.Id });
		}

		[Route("project/statistics/{projectId}")]
		public IActionResult Statistics(int projectId)
		{
			var model = new ProjectModel();
			var project = dbContext.ActiveProjects.Include(p => p.Blockchain).Where(p => p.Id == projectId && p.UserId == CurrentUser.Id).SingleOrDefault();

			if (project == null)
				return BadRequest("Project not found or access denied.");

			model.Project = project;
			model.Settings = settings;

			return View(model);
		}

	}
}
