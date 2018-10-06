using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JustBlog.Persistence;
using JustBlog.Persistence.Entities;

namespace JustBlog.Controllers
{
    public class PostCategoryController : Controller
    {
        private readonly JustBlogContext _context;

        public PostCategoryController(JustBlogContext context)
        {
            _context = context;
        }

        // GET: PostCategory
        public async Task<IActionResult> Index()
        {
            var justBlogContext = _context.PostCategoryEntity.Include(p => p.Category).Include(p => p.Post);
            return View(await justBlogContext.ToListAsync());
        }

        // GET: PostCategory/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryEntity = await _context.PostCategoryEntity
                .Include(p => p.Category)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (postCategoryEntity == null)
            {
                return NotFound();
            }

            return View(postCategoryEntity);
        }

        // GET: PostCategory/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName");
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "MainContent");
            return View();
        }

        // POST: PostCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,CategoryID")] PostCategoryEntity postCategoryEntity)
        {
            if (ModelState.IsValid)
            {
                postCategoryEntity.PostID = Guid.NewGuid();
                _context.Add(postCategoryEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", postCategoryEntity.CategoryID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "MainContent", postCategoryEntity.PostID);
            return View(postCategoryEntity);
        }

        // GET: PostCategory/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryEntity = await _context.PostCategoryEntity.FindAsync(id);
            if (postCategoryEntity == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", postCategoryEntity.CategoryID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "MainContent", postCategoryEntity.PostID);
            return View(postCategoryEntity);
        }

        // POST: PostCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PostID,CategoryID")] PostCategoryEntity postCategoryEntity)
        {
            if (id != postCategoryEntity.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCategoryEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCategoryEntityExists(postCategoryEntity.PostID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "CategoryName", postCategoryEntity.CategoryID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "MainContent", postCategoryEntity.PostID);
            return View(postCategoryEntity);
        }

        // GET: PostCategory/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryEntity = await _context.PostCategoryEntity
                .Include(p => p.Category)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (postCategoryEntity == null)
            {
                return NotFound();
            }

            return View(postCategoryEntity);
        }

        // POST: PostCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postCategoryEntity = await _context.PostCategoryEntity.FindAsync(id);
            _context.PostCategoryEntity.Remove(postCategoryEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCategoryEntityExists(Guid id)
        {
            return _context.PostCategoryEntity.Any(e => e.PostID == id);
        }
    }
}
