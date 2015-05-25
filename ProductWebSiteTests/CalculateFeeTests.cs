using LogisticLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

namespace ProductWebSiteTests
{
    [TestClass]
    public class CalculateFeeTests
    {
        [TestMethod]
        public void BlackcatTests()
        {
            //arrange
            var target = new Blackcat();
            var product = new ShippingProduct
            {
                Name = "book",
                Weight = 10,
                Size = new Size
                {
                    Length = 30,
                    Height = 10,
                    Width = 20
                }
            };

            //act
            target.CalculateFee(product);

            //asert
            var expected = 200;
            Assert.AreEqual(product.ShippingFee, expected);
        }

        [TestMethod]
        public void HsinChuTests()
        {
            //arrange
            var target = new HsinChu();
            var product = new ShippingProduct
            {
                Name = "book",
                Weight = 10,
                Size = new Size
                {
                    Length = 30,
                    Height = 10,
                    Width = 20
                }
            };

            //act
            target.CalculateFee(product);

            //asert
            var expected = 254.16;
            Assert.AreEqual(product.ShippingFee, expected);
        }

        [TestMethod]
        public void PostofficeTests()
        {
            //arrange
            var target = new Postoffice();
            var product = new ShippingProduct
            {
                Name = "book",
                Weight = 10,
                Size = new Size
                {
                    Length = 30,
                    Height = 10,
                    Width = 20
                }
            };

            //act
            target.CalculateFee(product);

            //asert
            var expected = 180;
            Assert.AreEqual(product.ShippingFee, expected);
        }
    }

    [TestClass]
    public class CalculateFeeWebTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        #region TestSetting

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:16207/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        #endregion TestSetting

        [TestMethod]
        public void TheLab6UnitTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Product.aspx");
            driver.FindElement(By.Id("MainContent_txtProductName")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductName")).SendKeys("Iphone6s");
            driver.FindElement(By.Id("MainContent_txtProductWeight")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductWeight")).SendKeys("10");
            driver.FindElement(By.Id("MainContent_txtProductLength")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductLength")).SendKeys("30");
            driver.FindElement(By.Id("MainContent_txtProductWidth")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductWidth")).SendKeys("20");
            driver.FindElement(By.Id("MainContent_txtProductHeight")).Clear();
            driver.FindElement(By.Id("MainContent_txtProductHeight")).SendKeys("10");
            driver.FindElement(By.Id("MainContent_drpCompany")).Click();
            new SelectElement(driver.FindElement(By.Id("MainContent_drpCompany"))).SelectByText("黑貓");
            //driver.FindElement(By.CssSelector("option[value=\"1\"]")).Click();
            driver.FindElement(By.Id("MainContent_btnCalculate")).Click();
            Assert.AreEqual("黑貓", driver.FindElement(By.Id("MainContent_lblCompany")).Text);
            Assert.AreEqual("200", driver.FindElement(By.Id("MainContent_lblCharge")).Text);
            driver.FindElement(By.Id("MainContent_drpCompany")).Click();
            new SelectElement(driver.FindElement(By.Id("MainContent_drpCompany"))).SelectByText("新竹貨運");
            //driver.FindElement(By.CssSelector("option[value=\"2\"]")).Click();
            driver.FindElement(By.Id("MainContent_btnCalculate")).Click();
            Assert.AreEqual("新竹貨運", driver.FindElement(By.Id("MainContent_lblCompany")).Text);
            Assert.AreEqual("254.16", driver.FindElement(By.Id("MainContent_lblCharge")).Text);
            new SelectElement(driver.FindElement(By.Id("MainContent_drpCompany"))).SelectByText("郵局");
            driver.FindElement(By.Id("MainContent_btnCalculate")).Click();
            Assert.AreEqual("郵局", driver.FindElement(By.Id("MainContent_lblCompany")).Text);
            Assert.AreEqual("180", driver.FindElement(By.Id("MainContent_lblCharge")).Text);
        }

        #region private method

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        #endregion private method
    }
}