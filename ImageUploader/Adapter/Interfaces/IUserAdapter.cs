using ImageUploader.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageUploader.Adapter.Interfaces
{
    public interface IUserAdapter
    {
        ImageGallery GetImage(int id);
        void AddImage(HttpPostedFileBase file, ImageGallery item, string user);

        List<ImageGallery> GetAllImages(string id);
    }
}