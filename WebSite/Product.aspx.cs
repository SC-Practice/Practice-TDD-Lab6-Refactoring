using System;

/** 重構之路* */
/* 1.使用 Selelium IDE, 在 CalculateFeeTest.cs 建立 UnitTest -> run test: green! */
/* 2.建立 ViewModel 類別, 增加 .aspx.cs & .aspx 之間的彈性 -> run test: green! Complexity:14 */
/* 3.抽出計算邏輯(private metohd Ctrl+R, Ctrl+M), 降低複雜度  -> run test: green! Complexity:6 */

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        var product = this.GetShippingProduct();
        if (this.IsValid)
        {
            if (this.drpCompany.SelectedValue == "1")
            {
                this.lblCompany.Text = "黑貓";
                CalculateBlackcatShipFee(product);
            }
            else if (this.drpCompany.SelectedValue == "2")
            {
                this.lblCompany.Text = "新竹貨運";
                CalculateShinChuShipFee(product);
            }
            else if (this.drpCompany.SelectedValue == "3")
            {
                this.lblCompany.Text = "郵局";
                CalculatePostOfficeShipFee(product);
            }
            else
            {
                var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
                this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
            }

            this.lblCharge.Text = product.ShippingFee.ToString();
        }
    }

    private static void CalculatePostOfficeShipFee(ShippingProduct product)
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

    private static void CalculateShinChuShipFee(ShippingProduct product)
    {
        var length = product.Size.Length;
        var width = product.Size.Width;
        var height = product.Size.Height;

        var size = length * width * height;

        //長 x 寬 x 高（公分）x 0.0000353
        if (length > 100 || width > 100 || height > 100)
        {
            product.ShippingFee = size * 0.0000353 * 1100 + 500;
        }
        else
        {
            product.ShippingFee = size * 0.0000353 * 1200;
        }
    }

    private static void CalculateBlackcatShipFee(ShippingProduct product)
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

    private ShippingProduct GetShippingProduct()
    {
        var result = new ShippingProduct
        {
            Name = this.txtProductName.Text,
            Weight = Convert.ToDouble(this.txtProductWeight.Text),
            Size = new Size
            {
                Length = Convert.ToDouble(this.txtProductLength.Text),
                Width = Convert.ToDouble(this.txtProductWidth.Text),
                Height = Convert.ToDouble(this.txtProductHeight.Text)
            },
            Shipper = Convert.ToInt32(this.drpCompany.SelectedValue)
        };

        return result;
    }
}

public class ShippingProduct
{
    public string Name { get; set; }

    public double Weight { get; set; }

    public Size Size { get; set; }

    public int Shipper { get; set; }

    public double ShippingFee { get; set; }
}

public struct Size
{
    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }
}