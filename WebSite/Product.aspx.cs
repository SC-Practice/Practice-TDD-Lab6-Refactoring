using System;

/** 重構之路* */
/* 1.使用 Selelium IDE, 在 CalculateFeeTest.cs 建立 UnitTest -> run test: green! */
/* 2.建立 ViewModel 抽離 .aspx.cs & .aspx 相依性 -> run test: green! */

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            if (this.drpCompany.SelectedValue == "1")
            {
                this.lblCompany.Text = "黑貓";
                var weight = Convert.ToDouble(this.txtProductWeight.Text);
                if (weight > 20)
                {
                    this.lblCharge.Text = "500";
                }
                else
                {
                    var fee = 100 + weight * 10;
                    this.lblCharge.Text = fee.ToString();
                }
            }
            else if (this.drpCompany.SelectedValue == "2")
            {
                this.lblCompany.Text = "新竹貨運";
                var length = Convert.ToDouble(this.txtProductLength.Text);
                var width = Convert.ToDouble(this.txtProductWidth.Text);
                var height = Convert.ToDouble(this.txtProductHeight.Text);

                var size = length * width * height;

                //長 x 寬 x 高（公分）x 0.0000353
                if (length > 100 || width > 100 || height > 100)
                {
                    this.lblCharge.Text = (size * 0.0000353 * 1100 + 500).ToString();
                }
                else
                {
                    this.lblCharge.Text = (size * 0.0000353 * 1200).ToString();
                }
            }
            else if (this.drpCompany.SelectedValue == "3")
            {
                this.lblCompany.Text = "郵局";

                var weight = Convert.ToDouble(this.txtProductWeight.Text);
                var feeByWeight = 80 + weight * 10;

                var length = Convert.ToDouble(this.txtProductLength.Text);
                var width = Convert.ToDouble(this.txtProductWidth.Text);
                var height = Convert.ToDouble(this.txtProductHeight.Text);
                var size = length * width * height;
                var feeBySize = size * 0.0000353 * 1100;

                if (feeByWeight < feeBySize)
                {
                    this.lblCharge.Text = feeByWeight.ToString();
                }
                else
                {
                    this.lblCharge.Text = feeBySize.ToString();
                }
            }
            else
            {
                var js = "alert('發生不預期錯誤，請洽系統管理者');location.href='http://tw.yahoo.com/';";
                this.ClientScript.RegisterStartupScript(this.GetType(), "back", js, true);
            }
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