using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pulsenics.Data;
using Pulsenics.Models;

namespace Pulsenics.Controllers
{
    public class FilesController : Controller
    {
        private readonly FilesContext _context;

        public FilesController(FilesContext context)
        {
            _context = context;
        }

        // GET: Files
        public async Task<IActionResult> Index(string fileName)
        {
            if (_context.FileSystem == null)
            {
                return Problem("Entity set 'FileContext.File'  is null.");
            }

            var files = from m in _context.FileSystem
                        select m;

            if (!String.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Inside Filter");
                files = files.Where(s => s.Name!.Contains(fileName));
            }

            return View(await files.ToListAsync());
        }

        // GET: Files/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FileSystem == null)
            {
                return NotFound();
            }

            var fileSystem = await _context.FileSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileSystem == null)
            {
                return NotFound();
            }

            return View(fileSystem);
        }

        // GET: Files/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Extension,CreatedDate,LastModifiedDate")] FileSystem fileSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileSystem);
        }

        // GET: Files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FileSystem == null)
            {
                return NotFound();
            }

            var fileSystem = await _context.FileSystem.FindAsync(id);
            if (fileSystem == null)
            {
                return NotFound();
            }
            return View(fileSystem);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Extension,CreatedDate,LastModifiedDate")] FileSystem fileSystem)
        {
            if (id != fileSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fileSystem.LastModifiedDate = DateTime.Now;
                    _context.Update(fileSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileSystemExists(fileSystem.Id))
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
            return View(fileSystem);
        }

        // GET: Files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FileSystem == null)
            {
                return NotFound();
            }

            var fileSystem = await _context.FileSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileSystem == null)
            {
                return NotFound();
            }

            return View(fileSystem);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FileSystem == null)
            {
                return Problem("Entity set 'FilesContext.FileSystem'  is null.");
            }
            var fileSystem = await _context.FileSystem.FindAsync(id);
            if (fileSystem != null)
            {
                _context.FileSystem.Remove(fileSystem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileSystemExists(int id)
        {
          return (_context.FileSystem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
