using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brake.AppDbContext;
using Brake.Controllers.Resources;
using Brake.Models;
using Brake.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brake.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class ModelController : Controller
    {
        private readonly BrakeDbContext _db;
        public readonly IMapper _mapper;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(BrakeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            ModelVM = new ModelViewModel()
            {
                Makes = db.Makes.ToList(),
                Model = new Models.Model()
            };
        }
        public IActionResult Index()
        {
            var model = _db.Models.Include(mbox => mbox.Make);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(ModelVM);
        }

        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Edit(int id)
        {
            ModelVM.Model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if (ModelVM.Model == null)
            {
                return NotFound();
            }
            return View(ModelVM);

        }

        [HttpPost,ActionName("Edit")]
        public IActionResult EditPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }

            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet("api/models/{MakeID}")]
        public IEnumerable<Model> Models(int MakeID)
        {
            return _db.Models.ToList().Where(m => m.MakeId==MakeID);
        }

        [AllowAnonymous]
        [HttpGet("api/models")]
        public IEnumerable<ModelResources> Models()
        {
            //return _db.Models.ToList();
            var models = _db.Models.ToList();

            
            return _mapper.Map<List<Model>, List<ModelResources>>(models);
        }
    }
}