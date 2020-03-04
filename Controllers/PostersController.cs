using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosterShop;

namespace PosterShop.Controllers
{
    public class PostersController : Controller
    {
        private readonly PosterShopContext _context;

        public PostersController(PosterShopContext context)
        {
            _context = context;
        }

        // GET: Posters
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Topics", "Index");

            ViewBag.TopicId = id;
            ViewBag.TopicName = name;
            
            var postersByTopic = _context.Posters.Where(b => b.TopicId == id).Include(b => b.Topic);
            return View(await postersByTopic.ToListAsync());
        }

        // GET: Posters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posters = await _context.Posters
                .Include(p => p.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posters == null)
            {
                return NotFound();
            }

            return View(posters);
        }

        // GET: Posters/Create
        public IActionResult Create(int topicId)
        {
            //ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name");
            ViewBag.TopicId = topicId;
            ViewBag.TopicName = _context.Topics.Where(c => c.Id == topicId).FirstOrDefault().Name;
            return View();
        }

        // POST: Posters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int topicId, [Bind("Id,Path,Price")] Posters posters)
        {
            posters.TopicId = topicId;
            if (ModelState.IsValid)
            {
                _context.Add(posters);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Posters", new { id = topicId, name = _context.Topics.Where(c => c.Id == topicId).FirstOrDefault().Name });
            }
            //ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name", posters.TopicId);
            //return View(posters);
            return RedirectToAction("Index", "Posters", new { id = topicId, name = _context.Topics.Where(c => c.Id == topicId).FirstOrDefault().Name });
        }

        // GET: Posters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posters = await _context.Posters.FindAsync(id);
            if (posters == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name", posters.TopicId);
            return View(posters);
        }

        // POST: Posters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,Price,TopicId")] Posters posters)
        {
            if (id != posters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostersExists(posters.Id))
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
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Name", posters.TopicId);
            return View(posters);
        }

        // GET: Posters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posters = await _context.Posters
                .Include(p => p.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posters == null)
            {
                return NotFound();
            }

            return View(posters);
        }

        // POST: Posters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posters = await _context.Posters.FindAsync(id);
            _context.Posters.Remove(posters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostersExists(int id)
        {
            return _context.Posters.Any(e => e.Id == id);
        }
    }
}
