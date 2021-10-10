using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        [TestMethod]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //arrange
            var configMobile = new ConfigTestMobile();
            //Crio um novo driver com os parâmetros da pasta do chrome driver e as options mobile
            driver = new ChromeDriver(TestHelper.pastaDoExecutavel, configMobile.EmularMobile(
                992,
                800,
                "Customizado"));


            new HomeNaoLogadaPO(driver)
                //act
                .Visitar();

            //assert
            var homePO = new HomeNaoLogadaPO(driver);
            Assert.IsTrue(homePO.Menu.MenuMobileVisivel);
        }

        [TestMethod]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //arrange 
            var configMobile = new ConfigTestMobile();
            //Crio um novo driver com os parâmetros da pasta do chrome driver e as options mobile
            driver = new ChromeDriver(TestHelper.pastaDoExecutavel, configMobile.EmularMobile(
                993,
                800,
                "Customizado"));

            new HomeNaoLogadaPO(driver)
                //act
                .Visitar();

            //assert
            var homePO = new HomeNaoLogadaPO(driver);
            Assert.IsFalse(homePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
