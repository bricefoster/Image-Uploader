using ImageUploader.Adapter.Interfaces;
using ImageUploader.Data;
using ImageUploader.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageUploader.Adapter.Adapters
{
    public class UserAdapter : IUserAdapter
    {
        public void AddImage(HttpPostedFileBase file, ImageGallery item, string user)
        {


            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                item.Image = ConvertToBytes(file);

                item.ApplicationUserId = user;

                db.ImageGalleries.Add(item);
                db.SaveChanges();
            }



        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public ImageGallery GetImage(int id)
        {
            ImageGallery image;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                image = db.ImageGalleries.Find(id);
            }

            return image;
        }

        public List<ImageGallery> GetAllImages(string id)
        {
            List<ImageGallery> images;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                images = db.ImageGalleries.Where(c => c.ApplicationUserId == id).ToList();
            }

            return images;
        }
    }
}