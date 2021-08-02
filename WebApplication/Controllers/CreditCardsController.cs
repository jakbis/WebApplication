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
    public class CreditCardsController : Controller
    {
        private readonly WebApplicationContext _context;

        public CreditCardsController(WebApplicationContext context)
        {
            _context = context;
        }
        
        // GET: CreditCards
        
        // GET: CreditCards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .FirstOrDefaultAsync(m => m.NumberCard == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }
        
        // GET: CreditCards/Create
        public IActionResult Create()
        {
            var q = _context.CreditCard.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);

            if (q == null)
            {
                return View();
            }
            else return RedirectToAction("AccessDenied", "Users");
        }

        

        // POST: CreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberCard,name,Date,Csv,UserName")] CreditCard creditCard)
       {
            if (ModelState.IsValid)
            {
                var q = _context.CreditCard.FirstOrDefault(u => u.UserName == creditCard.UserName);
                
                if (q == null)
                {
                    _context.Add(creditCard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), "Home");
                } else ViewData["Error"] = "You've already paid ! ";
            }
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var creditCard = await _context.CreditCard.FirstOrDefaultAsync(m => m.UserName == HttpContext.Session.GetString("username"));
            if (creditCard == null)
            {
                return NotFound();
            }
            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumberCard,name,Date,Csv,UserName")] CreditCard creditCard)
        {
            if (HttpContext.Session.GetString("username") == null && HttpContext.Session.IsAvailable)
            {
                return RedirectToAction("SignIn", "Users");
            }
            //if (id != creditCard.NumberCard)
            //{
            //    return NotFound();
            //}

            creditCard.UserName = HttpContext.Session.GetString("username");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardExists(creditCard.NumberCard))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Home");
            }
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("SignIn", "Users");
            }
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .FirstOrDefaultAsync(m => m.NumberCard == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var creditCard = await _context.CreditCard.FindAsync(id);
            _context.CreditCard.Remove(creditCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        private bool CreditCardExists(string id)
        {
            return _context.CreditCard.Any(e => e.NumberCard == id);
        }
    }
}
