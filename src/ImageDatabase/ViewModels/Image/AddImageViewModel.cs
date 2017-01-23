using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDatabase.ViewModels.Image
{
    public class AddImageViewModel
    {
		public ICollection<IFormFile> Files { get; set; }
	}
}
