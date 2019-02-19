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
            //Инициализируем драйвер.
            IWebDriver driver = new ChromeDriver();

            //Открываем страницу авторизации
            driver.Url = "https://accounts.google.com/";
            driver.Manage().Window.Maximize();
            
            //Вводим логин
            driver.FindElement(By.XPath("//*[@id=\"identifierId\"]")).SendKeys("automationt4@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Вводим невалидный пароль.
            driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input")).SendKeys("InvalidPassword");
            driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Получаем сообщение об ошибке
            string actualError = driver.FindElement(By.XPath("//*[@id=\"password\"]/div[2]/div[2]/div")).Text;
            string expectedError = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";

            //Сравниваем с ожидаемым результатом.
            Assert.AreEqual(actualError, expectedError);

            driver.Close();
        }

        [Test]
        public void ValidPassword()
        {
            //Инициализируем драйвер.
            IWebDriver driver = new ChromeDriver();

            //Открываем страницу авторизации
            driver.Url = "https://accounts.google.com/";

            driver.Manage().Window.Maximize();
            
            //Вводим логин
            driver.FindElement(By.XPath("//*[@id=\"identifierId\"]")).SendKeys("automationt4@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Вводим валидный пароль.
            driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input")).SendKeys("123automation");
            driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Получаем приветствие.
            string actualError = driver.FindElement(By.XPath("//div[2]/c-wiz/div[1]/c-wiz/c-wiz/div/div[4]/div/div/header/h1")).Text;
            string expectedError = "Добро пожаловать, Test Automation!";

            //Сравниваем с ожидаемым результатом.
            Assert.AreEqual(actualError, expectedError);



        }
    }
}
