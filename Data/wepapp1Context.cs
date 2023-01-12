using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wepapp1.Models;

namespace wepapp1.Data
{
    public class wepapp1Context : DbContext
    {
        public wepapp1Context (DbContextOptions<wepapp1Context> options)
            : base(options)
        {
        }

        public DbSet<UsersDB> UsersDB { get; set; } = default!;
    }
}
