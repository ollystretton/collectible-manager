﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollectibleManager.Models
{
	public class CollectibleImage
	{
		[Key]	
		public int Id { get; set; }
		[StringLength(255)]
		public string FileName { get; set; }
		[StringLength(100)]
		public string ContentType { get; set; }
		public byte[] Content { get; set; }
	}
}