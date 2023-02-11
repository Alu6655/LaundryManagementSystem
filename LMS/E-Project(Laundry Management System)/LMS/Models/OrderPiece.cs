using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class OrderPiece
    {
        public int pwid { get; set; }
        public string pwcode { get; set; }
        public string pwservice { get; set; }
        public string pwclothtype { get; set; }

        public decimal pwprice { get; set; }

    }
}