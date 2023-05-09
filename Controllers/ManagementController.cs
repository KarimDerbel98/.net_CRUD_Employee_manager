using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamTP.Models;

namespace ExamTP.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementDbContext _context;

        public ManagementController(ManagementDbContext context)
        {
            _context = context;
        }

        // GET: Management  
        public async Task<IActionResult> Index()
        {
            var managements = await _context.Managements.ToListAsync();
            if (managements != null)
            {
                return View(managements);
            }
            else
            {
                return Problem("Entity set 'ManagementDbContext.Managements' is null.");
            }
        }

       

        // GET: Management/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id==0)
                return View(new Management());
            else
                return View(_context.Managements.Find(id));
        }

        // POST: Management/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ManagementId,Name,Email,Salary,Date")] Management management)
        {
            if (ModelState.IsValid)
            {
                if (management.ManagementId == 0)
                {
                    management.Date = DateTime.Now;
                    _context.Add(management);
                }
                else
                    _context.Update(management);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(management);
        }

     
        // GET: Management/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Managements == null)
            {
                return NotFound();
            }

            var management = await _context.Managements
                .FirstOrDefaultAsync(m => m.ManagementId == id);
            if (management == null)
            {
                return NotFound();
            }

            return View(management);
        }

        // POST: Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Managements == null)
            {
                return Problem("Entity set 'ManagementDbContext.Managements'  is null.");
            }
            var management = await _context.Managements.FindAsync(id);
            if (management != null)
            {
                _context.Managements.Remove(management);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagementExists(int id)
        {
          return (_context.Managements?.Any(e => e.ManagementId == id)).GetValueOrDefault();
        }
    }
}
