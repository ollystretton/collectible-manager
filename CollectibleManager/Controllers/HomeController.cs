using CollectibleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CollectibleManager.ViewModels;

namespace CollectibleManager.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var collectibles = new List<Collectible>();

			using(var db = new CollectibleContext())
			{
				collectibles = db.Collectibles
					.Include(x => x.Manufacturer)
					.Include(x => x.Image)
					//.OrderBy(x => x.Manufacturer.Name)
					//.ThenBy(x => x.ModelNumber)
					.ToList();
			}

			return View(collectibles);
		}
		
		[HttpGet]
		public ActionResult AddManufacturer()
		{
			var model = new AddManufacturer();
			return View(model);
		}

		[HttpPost]
		public ActionResult AddManufacturer(AddManufacturer model)
		{
			if (ModelState.IsValid)
			{
				using (var db = new CollectibleContext())
				{
					var manufacturer = new CollectibleManufacturer
					{
						Name = model.Name
					};

					db.Manufacturers.Add(manufacturer);
					db.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult AddCollectible()
		{
			using (var db = new CollectibleContext())
			{
				var model = new AddCollectible
				{
					Manufacturers = db.Manufacturers.OrderBy(x => x.Name).ToList()
				};

				return View(model);
			}
		}

		[HttpPost]
		public ActionResult AddCollectible(AddCollectible model)
		{
			using (var db = new CollectibleContext())
			{
				if (ModelState.IsValid)
				{
					int? pictureId = null;
					if (model.Photo != null && model.Photo.ContentLength > 0)
					{
						var photo = new CollectibleImage
						{
							FileName = System.IO.Path.GetFileName(model.Photo.FileName),
							ContentType = model.Photo.ContentType
						};

						using (var reader = new System.IO.BinaryReader(model.Photo.InputStream))
						{
							photo.Content = reader.ReadBytes(model.Photo.ContentLength);
						}

						db.Images.Add(photo);
						db.SaveChanges();

						pictureId = photo.Id;
					}

					var collectible = new Collectible
					{
						DateLogged = DateTime.Now,
						DatePurchased = model.DatePurchased,
						Description = model.Description,
						EstimatedValue = model.EstimatedValue,
						PictureId = pictureId,
						ManufacturerId = model.ManufacturerId,
						ModelNumber = model.ModelNumber,
						ModelType = model.ModelType,
						PurchasePrice = model.PurchasePrice
					};

					db.Collectibles.Add(collectible);
					db.SaveChanges();

					return RedirectToAction("Index");
				}

				model.Manufacturers = db.Manufacturers.OrderBy(x => x.Name).ToList();

				return View(model);
			}
		}

		public ActionResult ViewCollectible(int id)
		{
			using (var db = new CollectibleContext())
			{
				var collectible = db.Collectibles
					.Include(x => x.Manufacturer)
					.Include(x => x.Image)
					.FirstOrDefault(x => x.Id == id);

				return View(collectible);
			}
   
		}
	}
}