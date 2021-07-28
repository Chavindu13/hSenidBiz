using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hSenidBiz.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public float Price { get; set; }
    }
}