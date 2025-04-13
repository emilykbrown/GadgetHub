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

        [Display(Name = "Gadget Name")]
        [Required(ErrorMessage = "Please enter a gadget name")]
        public string GadgetName { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Please enter a brand name")]
        public string GadgetBrand { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string GadgetDesc { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please enter a category")]
        public string GadgetCategory { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(0.01, 1000, ErrorMessage = "Please enter a positive price")]
        public decimal GadgetPrice { get; set; }
        [Display(Name = "Image")]
        public byte[] ImageData { get; set; }
        [Display(Name = "Image Mime Type")]
        public string ImageMimeType { get; set; }
    }
}
