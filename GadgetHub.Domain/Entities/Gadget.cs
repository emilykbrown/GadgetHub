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

        [HiddenInput(DisplayValue = false)]
        public int GadgetID { get; set; }

        [Display(Name = "Product Name")]
        public string GadgetName { get; set; }

        [Display(Name = "Brand")]
        public string GadgetBrand { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string GadgetDesc { get; set; }

        [Display(Name = "Category")]
        public string GadgetCategory { get; set; }

        [Display(Name = "Price")]
        public decimal GadgetPrice { get; set; }
    }
}
