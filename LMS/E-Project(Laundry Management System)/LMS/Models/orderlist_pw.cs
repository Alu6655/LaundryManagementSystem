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
    using System.Globalization;
    using System.Runtime;
    using System.Runtime.Serialization;

    public partial class orderlist_pw
    {
        [Display(Name = "Invoice No")]
        [Required]
        public int OPWid { get; set; }
        [Display(Name = "Customer")]
        [Required]
        public string OPWcust { get; set; }
        [Display(Name = "Service")]
        [Required]
        public string OPWservice { get; set; }
        [Display(Name = "Item Code")]
        [Required]
        public string OPWcode { get; set; }
        [Display(Name = "Qty")]
        [Required]
        public string OPWqty { get; set; }
        [Display(Name = "Order Date")]
        [Required]
        public System.DateTime OPWdate { get; set; }
        [Display(Name = "Delivery Date")]
        [Required]
        public System.DateTime OPWdel { get; set; }
        [Display(Name = "Due Payment")]
        [Required]
        public Nullable<decimal> OPWdue { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string OPWstat { get; set; }
        [Display(Name = "Total Amount")]
        [Required]
        public decimal OPWprice { get; set; }

        public Nullable<int> Cid { get; set; }
        [Display(Name = "Advance Payment")]
        [Required]
        public decimal OPWadvance { get; set; }
        public Nullable<int> PWid { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual priceList_pw priceList_pw { get; set; }
    }
}