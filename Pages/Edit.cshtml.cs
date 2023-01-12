using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wepapp1.Data;
using wepapp1.Models;

namespace wepapp1.Pages
{
    public class EditModel : PageModel
    {
        private readonly wepapp1.Data.wepapp1Context _context;

        public EditModel(wepapp1.Data.wepapp1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public UsersDB UsersDB { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersDB == null)
            {
                return NotFound();
            }

            var usersdb =  await _context.UsersDB.FirstOrDefaultAsync(m => m.ID == id);
            if (usersdb == null)
            {
                return NotFound();
            }
            UsersDB = usersdb;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UsersDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersDBExists(UsersDB.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UsersDBExists(int id)
        {
          return _context.UsersDB.Any(e => e.ID == id);
        }
    }
}
