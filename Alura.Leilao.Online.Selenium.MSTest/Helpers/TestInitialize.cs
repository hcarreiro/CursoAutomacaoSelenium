using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.Leilao.Online.Selenium.MSTest.Helpers
{
    [TestClass]
    public class TestInitialize
    {
        public static IWebDriver Driver { get; set; }

        //Com este atribudo este médoto será executado sempre que um [TestClass] for executado
        //dentro do escopo do projeto
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Driver = new ChromeDriver(TestHelper.pastaDoExecutavel);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //Com este atribudo este médoto será executado sempre que um [TestClass] for executado
        //dentro do escopo do projeto
        [AssemblyCleanup]
        public static void Cleanup()
        {
            Driver.Dispose();
        }

    }
}
