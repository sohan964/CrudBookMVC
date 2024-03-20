using CrudBookWeb.Data;
using CrudBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Catagory> objCategoryList = _db.Catagories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if(ModelState.IsValid)
            {
                _db.Catagories.Add(obj); //adding or sending Catagory to the database
                _db.SaveChanges(); //and saving it
                return RedirectToAction("Index"); //it's go to the Catagory Index page
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Catagories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj); //Updating Catagory to the database
                _db.SaveChanges(); //and saving it
                return RedirectToAction("Index"); //it's go to the Catagory Index page
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Catagories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Catagories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Catagories.Remove(obj); //Removing Catagory to the database
                _db.SaveChanges(); //and saving it
                return RedirectToAction("Index"); //it's go to the Catagory Index page
            
           
        }
    }
}
