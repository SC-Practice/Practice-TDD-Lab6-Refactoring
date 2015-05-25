namespace LogisticLib
{
    public class Postoffice : IShipping
    {
        public string Name
        {
            get { return "新竹貨運"; }
        }

        public void CalculateFee(ShippingProduct product)
        {
            var weight = product.Weight;
            var feeByWeight = 80 + weight * 10;

            var length = product.Size.Length;
            var width = product.Size.Width;
            var height = product.Size.Height;
            var size = length * width * height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                product.ShippingFee = feeByWeight;
            }
            else
            {
                product.ShippingFee = feeBySize;
            }
        }
    }
}