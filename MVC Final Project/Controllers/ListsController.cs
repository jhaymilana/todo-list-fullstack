using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Final_Project.Data;
using MVC_Final_Project.Models;

namespace MVC_Final_Project.Controllers
{
    public class ListsController : Controller
    {
        private readonly MVCFinalDbContext _context;

        public ListsController(MVCFinalDbContext context)
        {
            _context = context;
        }

        // GET: Lists
        public async Task<IActionResult> Index()
        {
              return _context.List != null ? 
                          View(await _context.List.ToListAsync()) :
                          Problem("Entity set 'MVCFinalDbContext.List'  is null.");
        }

        // GET: Lists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.List == null)
            {
                return NotFound();
            }

            List list = await _context.List.FirstOrDefaultAsync(m => m.Id == id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        // GET: Lists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] List list)
        {
            if (ModelState.IsValid)
            {
                _context.Add(list);
                await _context.SaveChangesAsync();

                int newListId = list.Id;
                return RedirectToAction("Details", new { id = newListId });
            }
            return View(list);
        }

        // GET: Lists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.List == null)
            {
                return NotFound();
            }

            List list = await _context.List.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] List list)
        {
            if (id != list.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(list);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListExists(list.Id))
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
            return View(list);
        }
        
        // GET: Lists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.List == null)
            {
                return NotFound();
            }

            List list = await _context.List.FirstOrDefaultAsync(m => m.Id == id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // if list doesnt exist
            if (_context.List == null)
            {
                return Problem("Entity set 'MVCFinalDbContext.List'  is null.");
            }

            List list = await _context.List.FindAsync(id);

            if (list != null)
            {
                _context.List.Remove(list);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // boolean to check list exists
        private bool ListExists(int id)
        {
          return (_context.List?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: Lists/AddTask/5
        public IActionResult AddTask(int listId)
        {
            List list = _context.List.Find(listId);

            if (list == null)
            {
                return NotFound();
            }

            MVC_Final_Project.Models.Task task = new MVC_Final_Project.Models.Task
            {
                ListId = list.Id
            };

            return View(task);
        }

        // POST: Lists/AddTask

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask([Bind("Id,Name,Description,DateOfCreation,Priority,Completion,ListId")] MVC_Final_Project.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                // Automatically set some of the properties
                task.DateOfCreation = DateTime.Now;
                task.Completion = Completion.ToDo;

                // Add and save
                _context.Add(task);
                await _context.SaveChangesAsync();

                // Return to the list where task as added
                return RedirectToAction("Details", "Lists", new { id = task.ListId });
            }
            // if fails reset
            return View(task);
        }
    }
}