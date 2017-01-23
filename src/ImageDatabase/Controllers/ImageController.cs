using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ImageDatabase.Entities;
using Microsoft.AspNetCore.Http;
using ImageDatabase.Infrastructure;
using System.IO;
using ImageDatabase.ViewModels.Image;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageDatabase.Controllers
{
    public class ImageController : Controller
    {
		// GET: /<controller>/
		private readonly Entities.ImageDatabaseDbContext _context;
		private IHostingEnvironment _environment;

		public ImageController(Entities.ImageDatabaseDbContext context, IHostingEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		public IActionResult Index()
        {

			Image[] images = _context.Images.ToArray();

			images.Reverse();

			var model = new IndexViewModel
			{
				Images = images.Select(
					x => new ImageViewModel
					{
						ImageSource = x.GetImageSourceFromImage()
					}).ToArray(),
			};

            return View(model);
        }

		[HttpGet]
		public IActionResult AddImage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddImage(ViewModels.Image.AddImageViewModel model)
		{
			if (model != null)
			{
				Image[] images = model.Files.Select(x => ImageInfrastructure.GetImageFromFormFile(x)).ToArray();
				foreach (var img in images)
					_context.Images.Add(img);
				_context.SaveChanges();

				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("AddImage");
			}
			
		}

		[HttpGet]
		public IActionResult ViewImage(int id)
		{
			Image[] images = _context.Images.ToArray();
			Image img = images.Where(i => i.Id == id).FirstOrDefault();

			var model = new ImageViewModel
			{
				ImageSource = img.GetImageSourceFromImage()
			};

			return View(model);
		}

		public ActionResult GetImageById(int ImageId)
		{
			Image img = _context.Images.Where(i => i.Id == ImageId).FirstOrDefault();

			var model = new ImageViewModel
			{
				ImageSource = img.GetImageSourceFromImage()
			};

			return PartialView(model);
		}
	}
}
