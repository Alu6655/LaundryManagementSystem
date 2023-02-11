using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class AllList
    {

        List<customer> cust { get; set; }
        List<orderlist_pkw> order_pkw { get; set; }
        List<orderlist_pw> order_pw { get; set; }
        List<orderlist_ww> order_ww { get; set; }
        List<priceList_pw> price_pw { get; set; }
        List<priceList_ww> price_ww { get; set; }
        List<priceList_pkw> price_pkw { get; set; }
        List<barcode> barcode { get; set; }

    }
}