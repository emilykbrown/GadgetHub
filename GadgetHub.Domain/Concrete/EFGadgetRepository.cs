using GadgetHub.Domain.Abstract;
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

        void IGadgetRepository.SaveGadget(Gadget gadget)
        {
            if (gadget.GadgetID == 0)
            {
                context.Gadgets.Add(gadget);
            }
            else
            {
                Gadget dbEntry = context.Gadgets.Find(gadget.GadgetID);
                if (dbEntry != null)
                {
                    dbEntry.GadgetName = gadget.GadgetName;
                    dbEntry.GadgetBrand = gadget.GadgetBrand;
                    dbEntry.GadgetDesc = gadget.GadgetDesc;
                    dbEntry.GadgetCategory = gadget.GadgetCategory;
                    dbEntry.GadgetPrice = gadget.GadgetPrice;
                }
            }
            context.SaveChanges();
        }


        public Gadget DeleteGadget(int gadgetID)
        {
            Gadget dbEntry = context.Gadgets.Find(gadgetID);
            if (dbEntry != null)
            {
                context.Gadgets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
} 