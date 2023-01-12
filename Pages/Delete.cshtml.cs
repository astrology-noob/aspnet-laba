using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wepapp1.Data;
using wepapp1.Models;

namespace wepapp1.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly wepapp1.Data.wepapp1Context _context;

        public DeleteModel(wepapp1.Data.wepapp1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public UsersDB UsersDB { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersDB == null)
            {
                return NotFound();
            }

            var usersdb = await _context.UsersDB.FirstOrDefaultAsync(m => m.ID == id);

            if (usersdb == null)
            {
                return NotFound();
            }
            else 
            {
                UsersDB = usersdb;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UsersDB == null)
            {
                return NotFound();
            }
            var usersdb = await _context.UsersDB.FindAsync(id);

            if (usersdb != null)
            {
                UsersDB = usersdb;
                _context.UsersDB.Remove(UsersDB);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
