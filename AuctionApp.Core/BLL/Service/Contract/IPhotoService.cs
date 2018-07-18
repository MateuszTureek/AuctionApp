using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IPhotoService
    {
        void AddPhoto(IFormFile file);
        string GetFilePath(IFormFile file);
    }
}
