using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hSenidBiz.Models
{
    public class Bill
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Sub Total")]
        [Required(ErrorMessage = "This field is required!")]
        public float SubTotal { get; set; }

        [DisplayName("Discount")]
        [Required(ErrorMessage = "This field is required!")]
        public float Discount { get; set; }

        [DisplayName("VAT")]
        [Required(ErrorMessage = "This field is required!")]
        public float Vat { get; set; }

        [DisplayName("Total")]
        [Required(ErrorMessage = "This field is required!")]
        public float Total { get; set; }

        [Required]
        public ICollection<Detail> Details { get; set; }
    }
}