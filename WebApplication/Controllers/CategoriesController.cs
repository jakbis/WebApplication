using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebProject.Models;

namespace WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly WebApplicationContext _context;

        public CategoriesController(WebApplicationContext context)
        {
            _context = context;
        }
        
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Category.ToListAsync());
        }

        //public async Task<IActionResult> ClientIndex()
        //{
        //    return View(await _context.Category.ToListAsync());
        //}


        //public IActionResult Sweet()
        //{
        //    return this.RedirectToAction("Sweet", "Recipes");
        //}
        //public IActionResult Salty()
        //{
        //    return this.RedirectToAction("Salty", "Recipes");
        //}
        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            string dir = null;
            if (id == null)
            {
                return NotFound();
            }
            if (id == 1)
            {
                dir = "Sweet";
            }
            if (id == 2)
            {
                dir = "Salty";
            }
            if (id == 4)
            {
                dir = "Cakes";
            }
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return this.RedirectToAction(dir, "Recipes", new { id });
        }



        // GET: Categories/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("SignIn", "Users");
            }
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,ImagePath")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [Authorize]
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("SignIn", "Users");
            }
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,ImagePath")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("SignIn", "Users");
            }
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
