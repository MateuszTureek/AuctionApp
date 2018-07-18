using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class PhotoService : IPhotoService
    {
        readonly IHostingEnvironment _hostingEnvironment;

        public PhotoService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetFilePath(IFormFile file)
        {
            var uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\items");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            return filePath;
        }

        public void AddPhoto(IFormFile file)
        {
            var filePath = GetFilePath(file);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
