using CollectibleManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollectibleManager.ViewModels
{
	public class AddCollectible
	{
		[Display(Name="Manufacturer")]
		public int ManufacturerId { get; set; }
		[Required]
		[Display(Name = "Model Type")]
		public string ModelType { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[Display(Name = "Model Number")]
		public string ModelNumber { get; set; }
		[Display(Name = "Date Purchase")]
		public DateTime? DatePurchased { get; set; }
		[Display(Name = "Purchase Price")]
		public double? PurchasePrice { get; set; }
		[Display(Name = "Estimated Value")]
		public double? EstimatedValue { get; set; }
		[Display(Name = "Photo")]
		public HttpPostedFileBase Photo { get; set; }

		public List<CollectibleManufacturer> Manufacturers { get; set; }
	}
}