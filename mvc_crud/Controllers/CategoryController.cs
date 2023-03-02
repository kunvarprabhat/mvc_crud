using Microsoft.AspNetCore.Mvc;
using mvc_crud.Data;
using mvc_crud.Models;

namespace mvc_crud.Controllers
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
            IEnumerable<Category> objCategoryList  = _db.Categories;
            return View(objCategoryList);
        } 
        // GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display cannot exectly match  the Nmae.");
            }
            if (ModelState.IsValid)
            {
                _db .Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        } public IActionResult Edit()
        {
            IEnumerable<Category> objCategoryList  = _db.Categories;
            return View(objCategoryList);
        } 
        // GET
        public IActionResult Edit( int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            //var objCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }
            return View(categoryFormDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display cannot exectly match  the Nmae.");
            }
            if (ModelState.IsValid)
            {
                _db .Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        public IActionResult Delete( int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            //var objCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }
            return View(categoryFormDb);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id )
        {  
            var obj = _db.Categories.Find(id); 
            if (obj == null)
            {
                return NotFound();
            }
            
                _db .Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }
    }
           
}
            
            
        
        
        
        
