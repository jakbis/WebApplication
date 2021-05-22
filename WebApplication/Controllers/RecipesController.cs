﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebProject.Models;

namespace WebApplication.Controllers
{
    public class RecipesController : Controller
    {
        private readonly WebApplicationContext _context;

        public RecipesController(WebApplicationContext context)
        {
            _context = context;
        }

        // GET: Recipes
        //public async Task<IActionResult> Index()
        //{
        //    var webApplicationContext = _context.Recipe.Include(r => r.Category);
        //    return View(await webApplicationContext.ToListAsync());
        //}

        public async Task<IActionResult> Salty(int? id)
        {
            var webApplicationContext = _context.Recipe.Where(r => r.CategoryId == id);
            //var webApplicationContext = _context.Recipe.Include(r => r.Category);
            return View(await webApplicationContext.ToListAsync());
        }

        public async Task<IActionResult> Sweet(int? id)
        {
            var webApplicationContext = _context.Recipe.Where(r => r.CategoryId == id);
            //var webApplicationContext = _context.Recipe.Include(r => r.Category);
            return View(await webApplicationContext.ToListAsync());
        }

        public async Task<IActionResult> Cakes(int? id)
        {
            var webApplicationContext = _context.Recipe.Where(r => r.CategoryId == id);
            //var webApplicationContext = _context.Recipe.Include(r => r.Category);
            return View(await webApplicationContext.ToListAsync());
        }
        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create(int? id)
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name");
            return View();
        }
        //public IActionResult Sweet()
        //{
        //    return View();
        //}
        //public IActionResult Salty()
        //{
        //    return View();
        //}
        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,Name,CategoryId,ImagePath,Body,Price,Video,Howtomake")] Recipe recipe)
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "ImagePath", recipe.CategoryId);
            string catname = null;
            if (ModelState.IsValid)
            {
                switch (recipe.CategoryId)
                {
                    case 1:
                        catname = "Sweet";
                        break;
                    case 2:
                        catname = "Salty";
                        break;
                    case 4:
                        catname = "Cakes";
                        break;

                }
                int id;

                id = recipe.CategoryId;

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(catname, "Recipes", new { id });
            }
            
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", recipe.CategoryId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,CategoryId,ImagePath,Body,Price,Video,Howtomake")] Recipe recipe)
        {
            string catname = null;
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", recipe.CategoryId);
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    switch (recipe.CategoryId)
                    {
                        case 1:
                            catname = "Sweet";
                            break;
                        case 2:
                            catname = "Salty";
                            break;
                        case 4:
                            catname = "Cakes";
                            break;

                    }
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                id = recipe.CategoryId;
                await _context.SaveChangesAsync();
                return RedirectToAction(catname, "Recipes", new { id });
            }
           
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var recipe = await _context.Recipe.FindAsync(id);
            var recipe2 = recipe;
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            
            switch (recipe.CategoryId)
            {
                case 1:
                    return RedirectToAction(nameof(Sweet), new { id = 1 });
                case 2:
                    return RedirectToAction(nameof(Salty), new { id = 2 });
                case 4:
                    return RedirectToAction(nameof(Cakes), new { id = 4 });
            }
            //return RedirectToAction(nameof(Index));
            return View(recipe);

        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeId == id);
        }
    }
}
