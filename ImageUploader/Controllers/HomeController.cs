using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using ImageUploader.Adapter.Interfaces;
using ImageUploader.Adapter.Adapters;
using ImageUploader.Data.Model;
using ImageUploader.Data;
using Microsoft.AspNet.Identity;

namespace ImageUploader.Controllers
{
    public class HomeController : Controller
    {
       
            IUserAdapter _adapter;
            public HomeController()
            {
                _adapter = new UserAdapter();
            }

            public HomeController(IUserAdapter adapter)
            {
                _adapter = adapter;
            }

            public ActionResult Index()
            {

                return View();

            }

            [Authorize]
            // GET: Member
            public ActionResult ViewImage()
            {
                string id = User.Identity.GetUserId();
                List<ImageGallery> model = _adapter.GetAllImages(id);

                return View(model);
            }

            public ActionResult GetImage(int id)
            {
                var image = _adapter.GetImage(id);

                byte[] cover = image.Image;

                if (cover != null)
                {
                    return File(cover, "image/jpg");
                }
                else
                {
                    return null;
                }


            }

            [Authorize]
            public ActionResult Create()
            {

                return View();
            }

            [Route("Create")]
            [HttpPost]
            public ActionResult Create(ImageGallery model)
            {
                string id = User.Identity.GetUserId();

                HttpPostedFileBase file = Request.Files["ImageData"];

                _adapter.AddImage(file, model, id);

                return RedirectToAction("ViewImage");
            }
        }
    }
