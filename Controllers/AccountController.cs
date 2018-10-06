using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustBlog.Persistence;
using JustBlog.Persistence.Entities;

namespace JustBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly JustBlogContext _context;

        public AccountController(JustBlogContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.Accounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            return View(accountEntity);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,FirstName,LastName")] AccountEntity accountEntity)
        {
            if (ModelState.IsValid)
            {
                accountEntity.ID = Guid.NewGuid();
                _context.Add(accountEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountEntity);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.Accounts.FindAsync(id);
            if (accountEntity == null)
            {
                return NotFound();
            }
            return View(accountEntity);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,UserName,Password,FirstName,LastName")] AccountEntity accountEntity)
        {
            if (id != accountEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountEntityExists(accountEntity.ID))
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
            return View(accountEntity);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountEntity = await _context.Accounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accountEntity == null)
            {
                return NotFound();
            }

            return View(accountEntity);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var accountEntity = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(accountEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountEntityExists(Guid id)
        {
            return _context.Accounts.Any(e => e.ID == id);
        }
    }
}
