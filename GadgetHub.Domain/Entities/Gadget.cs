using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GadgetHub.Domain.Entities
{
    public class Gadget
    {
        [HiddenInput (DisplayValue = false)]
        public int GadgetID { get; set; }
        public string GadgetName { get; set; }
        public string GadgetBrand { get; set; }

        [DataType(DataType.MultilineText)]
        public string GadgetDesc { get; set; }
        public string GadgetCategory { get; set; }
        public decimal GadgetPrice { get; set; }

    }
}
