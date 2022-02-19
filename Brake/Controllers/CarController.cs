using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brake.AppDbContext;
using Brake.Models;
using Brake.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Brake.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly BrakeDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public CarViewModel CarVM { get; set; }

        public CarController(BrakeDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            CarVM = new CarViewModel()
            {
                Makes = db.Makes.ToList(),
                Models = db.Models.ToList(),
                Car = new Models.Car()
            };
        }
        public IActionResult Index()
        {
            var cars = _db.Cars.Include(mbox => mbox.Make).Include(M => M.Model);
            return View(cars.ToList());
        }

        public IActionResult Create()
        {
            return View(CarVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                CarVM.Makes = _db.Makes.ToList();
                CarVM.Models = _db.Models.ToList();
                return View(CarVM);
            }
            _db.Cars.Add(CarVM.Car);
            _db.SaveChanges();

            var CarID = CarVM.Car.Id;

            string wwrootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var SavedCar = _db.Cars.Find(CarID);

            if (files.Count != 0)
            {
                var ImagePath = @"images\car\";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + CarID + Extension;
                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                SavedCar.ImagePath = RelativeImagePath;
                _db.SaveChanges();

            }



            return RedirectToAction(nameof(Index));


        }

        //public IActionResult Edit(int id)
        //{
        //    ModelVM.Model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
        //    if (ModelVM.Model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ModelVM);

        //}

        //[HttpPost, ActionName("Edit")]
        //public IActionResult EditPost(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ModelVM);
        //    }

        //    _db.Update(ModelVM.Model);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));

        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Car car = _db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}