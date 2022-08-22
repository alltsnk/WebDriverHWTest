using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverHWTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _searchField = By.XPath("//div[@class]/input");
        private readonly By _imagesButton = By.XPath("//a[text()='Картинки']");
        private readonly By _isImage = By.XPath("//img[not(@style='hidden')]");

        private const bool expectedResult = true;
        private bool actualResult;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var search = driver.FindElement(_searchField);
            search.SendKeys("image");
            search.Submit();

            var images = driver.FindElement(_imagesButton);
            images.Click();

            List<IWebElement> isimage = driver.FindElements(_isImage).ToList();

            foreach(var image in isimage)
            {
                if(image != null)
                {
                    actualResult = true;
                    break;
                }
                else
                {
                    actualResult = false;
                }
            }

            Assert.AreEqual(expectedResult, actualResult, "There is no images on the tab");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}