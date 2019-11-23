using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectibleManager.Models
{
	public class CollectibleManufacturer
	{
		public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
	}
}