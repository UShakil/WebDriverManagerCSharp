using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Tests
{
    public class DriverManagerTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            string browser = Environment.GetEnvironmentVariable("browser", EnvironmentVariableTarget.Process);
            switch (browser)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
            }
            _driver.Url = "https://github.com/rosolko/WebDriverManager.Net";            
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(_driver.FindElement(By.CssSelector("span[itemprop = 'about']")).Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}