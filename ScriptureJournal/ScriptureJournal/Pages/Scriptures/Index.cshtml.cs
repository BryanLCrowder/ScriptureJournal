using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Models.ScriptureJournalContext _context;
        

        public IndexModel(ScriptureJournal.Models.ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
  
        public SelectList Book { get; set; }
        public SelectList DateAdded { get; set; }
       
        public string ScriptureBook { get; set; }
        

        public async Task OnGetAsync(string scriptureBook, string searchString, DateTime dateAdd)
        {

            
            IQueryable<DateTime?>dateQuery = from a in _context.Scripture
                                             orderby a.DateAdded
                                             select a.DateAdded;

            IQueryable<string> scriptureQuery = from b in _context.Scripture
                                            orderby b.Book
                                            select b.Book;

            var scriptures = from b in _context.Scripture
                         select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(z => z.Title.Contains(searchString) || z.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(scriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == scriptureBook);
            }

            if (dateAdd  == DateTime.MaxValue)
            {
                scriptures = scriptures.Where(n => n.DateAdded == dateAdd);
            }
            
            Book = new SelectList(await scriptureQuery.Distinct().ToListAsync());
            DateAdded = new SelectList(await dateQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
            
        }
    }
}
