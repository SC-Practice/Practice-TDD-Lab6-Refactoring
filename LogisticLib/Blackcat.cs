namespace LogisticLib
{
    public class Blackcat : IShipping
    {
        public string Name { get { return "黑貓"; } }

        public void CalculateFee(ShippingProduct product)
        {
            var weight = product.Weight;
            if (weight > 20)
            {
                product.ShippingFee = 500;
            }
            else
            {
                var fee = 100 + weight * 10;
                product.ShippingFee = fee;
            }
        }
    }
}