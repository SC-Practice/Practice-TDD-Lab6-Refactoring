using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticLib
{
    public interface IShipping
    {
        void CalculateFee(ShippingProduct product);
    }
}
