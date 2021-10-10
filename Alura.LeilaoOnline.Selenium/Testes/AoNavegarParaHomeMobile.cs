using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        public AoNavegarParaHomeMobile()
        {
        }

        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //arrange 
            var configMobile = new ConfigTesteMobile();
            //Crio um novo driver com os parâmetros da pasta do chrome driver e as options mobile
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, configMobile.EmularMobile(
                992,
                800,
                "Customizado"));


            new HomeNaoLogadaPO(driver)
                //act
                .Visitar();

            //assert
            var homePO = new HomeNaoLogadaPO(driver);
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            //arrange 
            var configMobile = new ConfigTesteMobile();
            //Crio um novo driver com os parâmetros da pasta do chrome driver e as options mobile
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, configMobile.EmularMobile(
                993,
                800,
                "Customizado"));

            new HomeNaoLogadaPO(driver)
                //act
                .Visitar();

            //assert
            var homePO = new HomeNaoLogadaPO(driver);
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
