using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadWebApplication.DAL
{
    public class BadContext : DbContext
    {
        public BadContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
