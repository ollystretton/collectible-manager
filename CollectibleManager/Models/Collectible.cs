using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectibleManager.Models
{
	public class Collectible
	{
		[Key]
		public int Id { get; set; }
		public int ManufacturerId { get; set; }
        [StringLength(200)]
        public string ModelType { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string ModelNumber { get; set; }
		public DateTime? DatePurchased { get; set; }
		public DateTime DateLogged { get; set; }
		public double? PurchasePrice { get; set; }
		public double? EstimatedValue { get; set; }
		public int? PictureId { get; set; }

		[ForeignKey("PictureId")]
		public virtual CollectibleImage Image { get; set; }

		[ForeignKey("ManufacturerId")]
		public virtual CollectibleManufacturer Manufacturer { get; set; }
	}
}