using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject6
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void InvalidPassword()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://accounts.google.com/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//*[@id=\"identifierId\"]")).SendKeys("automationt4@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input")).SendKeys("InvalidPassword");
            driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            string actualError = driver.FindElement(By.XPath("//*[@id=\"password\"]/div[2]/div[2]/div")).Text;
            string expectedError = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";

            Assert.AreEqual(actualError, expectedError);

            driver.Close();
        }

        [Test]
        public void ValidPassword()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://accounts.google.com/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//*[@id=\"identifierId\"]")).SendKeys("automationt4@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input")).SendKeys("123automation");
            driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            string actualError = driver.FindElement(By.XPath("//div[2]/c-wiz/div[1]/c-wiz/c-wiz/div/div[4]/div/div/header/h1")).Text;
            string expectedError = "Добро пожаловать, Test Automation!";

            Assert.AreEqual(actualError, expectedError);

            driver.Quit();

        }
    }
}
