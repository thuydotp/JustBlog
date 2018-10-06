using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JustBlog.Persistence;
using JustBlog.Persistence.Entities;

namespace JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly JustBlogContext _context;

        public PostController(JustBlogContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var justBlogContext = _context.Posts.Include(p => p.Author);
            return View(await justBlogContext.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postEntity = await _context.Posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (postEntity == null)
            {
                return NotFound();
            }

            return View(postEntity);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Accounts, "ID", "FirstName");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ShortDescription,MainContent,Slug,CreatedDate,UpdatedDate,ThumbnailImage,AuthorID")] PostEntity postEntity)
        {
            if (ModelState.IsValid)
            {
                postEntity.ID = Guid.NewGuid();
                _context.Add(postEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Accounts, "ID", "FirstName", postEntity.AuthorID);
            return View(postEntity);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postEntity = await _context.Posts.FindAsync(id);
            if (postEntity == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Accounts, "ID", "FirstName", postEntity.AuthorID);
            return View(postEntity);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Title,ShortDescription,MainContent,Slug,CreatedDate,UpdatedDate,ThumbnailImage,AuthorID")] PostEntity postEntity)
        {
            if (id != postEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostEntityExists(postEntity.ID))
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
            ViewData["AuthorID"] = new SelectList(_context.Accounts, "ID", "FirstName", postEntity.AuthorID);
            return View(postEntity);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postEntity = await _context.Posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (postEntity == null)
            {
                return NotFound();
            }

            return View(postEntity);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postEntity = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(postEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostEntityExists(Guid id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }
    }
}
