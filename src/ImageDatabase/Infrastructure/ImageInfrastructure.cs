using ImageDatabase.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDatabase.Infrastructure
{
    public static class ImageInfrastructure
    {
		public static Image GetImageFromFormFile(this IFormFile formFile)
		{
			using (Stream stream = formFile.OpenReadStream())
			using (var memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);

				var image = new Image
				{
					ImageBytes = memoryStream.ToArray(),
					ImageType = formFile.ContentType,
				};

				return image;
			}
		}

		public static string GetImageSourceFromImage(this Image image)
		{
			string base64 = Convert.ToBase64String(image.ImageBytes);

			string imageSource = $"data:{image.ImageType};base64,{base64}";

			return imageSource;
		}
	}
}
