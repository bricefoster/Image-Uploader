using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUploader.Data.Model
{
    public class ImageGallery
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }
        public virtual ApplicationUser user { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
