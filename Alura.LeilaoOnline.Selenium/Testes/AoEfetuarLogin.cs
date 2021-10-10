using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        /*Gero o construtor da classe para receber uma instância do navegado do tipo TestFixture
         * (TestFixture apenas realiza a instância de um driver para o Chorme passando o caminho do driver)*/
        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;    
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                //act
                .SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            //arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("")
                .SubmeteFormulario();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
