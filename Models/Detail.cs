using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hSenidBiz.Models
{
    public class Detail
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Item")]
        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public float Price { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public float Amount { get; set; }

        [Required]
        public virtual Bill Bill { get; set; }
    }
}