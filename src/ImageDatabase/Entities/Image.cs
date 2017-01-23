using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDatabase.Entities
{
    public class Image
    {
		public int Id { get; set; }
		
		[Required]
		public string ImageType { get; set; }

		[Required]
		public byte[] ImageBytes { get; set; }
	}
}
