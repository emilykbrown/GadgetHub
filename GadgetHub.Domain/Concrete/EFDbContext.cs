using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Entities
{
    public class EFDbContext : DbContext
    {
        public DbSet<Gadget> Gadgets { get; set; }
    }
}
