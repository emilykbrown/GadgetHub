﻿using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Concrete
{
    public class EFGadgetRepository : IGadgetRepository
    {
        private readonly EFDbContext context = new EFDbContext();    
        public IEnumerable<Gadget> Gadgets
        {
            get { return context.Gadgets; }
        }
    }
}