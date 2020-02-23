using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;
using ScriptureJournal.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalContext _context;

        public IndexModel(ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            BookSort = sortOrder == "book_asc" ? "book_desc" : "book_asc";
            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from s in _context.Scripture
                                            orderby s.Book
                                            select s.Book;

            var scriptures = from s in _context.Scripture
                         select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(n => n.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }

            switch (sortOrder)
            {
                case "book_asc":
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "date_asc":
                    scriptures = scriptures.OrderByDescending(s => s.Date);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderBy(s => s.Date);
                    break;
                default:
                    break;
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
