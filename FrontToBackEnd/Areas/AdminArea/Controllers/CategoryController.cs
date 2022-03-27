using FrontToBackEnd.Data;
using FrontToBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackEnd.Areas.Areas.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        
        private readonly AppDbContext _context;
            public CategoryController(AppDbContext context)
            {
                _context = context;
            }
        public async Task<IActionResult> Index()
        {

            List<Category> categories = await _context.Categories.Where(m => m.IsDeleted == false).ToListAsync();
            return View(categories);
        }

        public IActionResult Detail(int id)
            {
                var category = _context.Categories.FirstOrDefault(m => m.Id == id);
                return View(category);
                //return Json(new
                //{
                //    categoryName = category.Name,
                //    cetegoryDet=category.Products,
                //    action = "Detail",
                //    Id = id

                //}); 
            }
            public IActionResult Edit(int id)
            {
                return Json(new
                {
                    action = "Edit",
                    Id = id

                });
            }
            public IActionResult Delete(int id)
            {
                return Json(new
                {
                    action = "Delete",
                    Id = id

                });
            }
        }
    
}
