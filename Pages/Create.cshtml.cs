using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wepapp1.Data;
using wepapp1.Models;

namespace wepapp1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly wepapp1.Data.wepapp1Context _context;

        public CreateModel(wepapp1.Data.wepapp1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UsersDB UsersDB { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UsersDB.Add(UsersDB);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
