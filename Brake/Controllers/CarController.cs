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
using cloudscribe.Pagination.Models;

namespace Brake.Controllers
{
    //[Authorize(Roles = "Admin,Executive")]
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

        public IActionResult Index(string searchString, string sortOrder, int pageNumber=1, int pageSize=3)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.PriceSortParam = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            ViewBag.CurrentFilter = searchString;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;


            var cars = from b in _db.Cars.Include(mbox => mbox.Make).Include(M => M.Model)
                       select b;

            var CarCount = cars.Count();
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(b => b.Make.Name.Contains(searchString));
                CarCount = cars.Count();
            }

            switch (sortOrder)
            {
                case "price_desc":
                    cars = cars.OrderByDescending(b => b.Price);
                    break;
                default:
                    cars = cars.OrderBy(b => b.Price);
                    break;
            }


            cars=cars
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<Car>
            {
                Data = cars.AsNoTracking().ToList(),
                TotalItems = CarCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return View(result);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                CarVM.Makes = _db.Makes.ToList();
                CarVM.Models = _db.Models.ToList();
                return View(CarVM);
            }
            _db.Cars.Update(CarVM.Car);

            UploadImageIfAvailable();

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));


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
            
            UploadImageIfAvailable();

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));


        }

        private void UploadImageIfAvailable()
        {
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
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarVM.Car = _db.Cars.SingleOrDefault(b => b.Id == id);

            CarVM.Models = _db.Models.Where(m => m.MakeId == CarVM.Car.MakeID);
            if (CarVM.Car == null)
            {
                return NotFound();
            }
            return View(CarVM);

        }

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

        [HttpGet]
        public IActionResult View(int id)
        {
            CarVM.Car = _db.Cars.SingleOrDefault(b => b.Id == id);


            if (CarVM.Car == null)
            {
                return NotFound();
            }
            return View(CarVM);

        }
    }
}