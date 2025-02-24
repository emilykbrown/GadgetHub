using GadgetHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GadgetHub.WebUI.Models
{
    public class GadgetsListViewModel
    {
        public IEnumerable<Gadget> Gadgets { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}