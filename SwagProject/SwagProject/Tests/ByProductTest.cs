using NUnit.Framework;
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


        [SetUp]
        public void SetUp()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();

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

    

       
    }
     
}
