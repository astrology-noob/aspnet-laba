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
    public class IndexModel : PageModel
    {
        private readonly wepapp1.Data.wepapp1Context _context;

        public IndexModel(wepapp1.Data.wepapp1Context context)
        {
            _context = context;
        }

        public IList<UsersDB> UsersDB { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UsersDB != null)
            {
                UsersDB = await _context.UsersDB.ToListAsync();
            }
        }
    }
}
