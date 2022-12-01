using NUnit.Framework;
using OpenQA.Selenium;
using SwagProject.Driver;
using SwagProject.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagProject.Tests
{
    public class ByProductTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private CardPage cardPage;
        


        [SetUp]
        public void SetUp()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
            

        }
        
        [TearDown]
        public void CleanUp()
        {
            WebDrivers.CleanUp();
        }

        [Test] 
        public void TC01_AddToProductInCard_ShouldDisplayedTwoProduct()
        {
            loginPage.Username.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.LoginButton.Submit();

            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2",Is.EqualTo(productPage.Cart.Text));
        }

        [Test]
        public void TC02_SortProductByPrice_ShouldSortByPrice()
        {
            loginPage.Username.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.LoginButton.Submit();

            productPage.SelectOption("Price (high to low)");

            Assert.That(productPage.SortByPrice.Displayed);
        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedactionToNewPage()
        {
            loginPage.Username.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.LoginButton.Submit();

            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC04_BuyProduct_ShouldBeFinishedShopping()
        {
            loginPage.Username.SendKeys("standard_user");
            loginPage.Password.SendKeys("secret_sauce");
            loginPage.LoginButton.Submit();

            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            cardPage.ShoppingCardClick.Click();
            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("Antonina");
            cardPage.LastName.SendKeys("Tasic");
            cardPage.PastalCode.SendKeys("11000");
            cardPage.Continue.Click();
            cardPage.Finish.Click();

            Assert.That("https://www.saucedemo.com/checkout-complete.html", Is.EqualTo(WebDrivers.Instance.Url));
            
        }
    }     
}
