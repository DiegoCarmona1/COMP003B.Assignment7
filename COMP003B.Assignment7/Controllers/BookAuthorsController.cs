﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Assignment7.Data;
using COMP003B.Assignment7.Models;

namespace COMP003B.Assignment7.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public BookAuthorsController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: BookAuthors
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.BookAuthors.Include(b => b.Authors).Include(b => b.Books);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: BookAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Authors)
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            return View();
        }

        // POST: BookAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,AuthorId")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,AuthorId")] BookAuthor bookAuthor)
        {
            if (id != bookAuthor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Authors)
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
            return _context.BookAuthors.Any(e => e.Id == id);
        }
    }
}
