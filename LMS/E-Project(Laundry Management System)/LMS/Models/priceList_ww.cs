//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class priceList_ww
    {
        [Display(Name = "ID")]
        [Required]
        public int PWid { get; set; }
        [Display(Name = "Item Code")]
        [Required]
        public string PWcode { get; set; }
        [Display(Name = "Service")]
        [Required]
        public string PWservice { get; set; }
        [Display(Name = "Box Weight(KG)")]
        [Required]
        public int PWboxweight { get; set; }
        [Display(Name = "Total Amount")]
        [Required]
        public decimal PWprice { get; set; }
    }
}
