using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticLib
{
    public class ShippingProduct
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public Size Size { get; set; }

        public int Shipper { get; set; }

        public double ShippingFee { get; set; }
    }
}
