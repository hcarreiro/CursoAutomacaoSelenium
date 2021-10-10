using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixtura)
        {
            this.driver = fixtura.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveOfertarLanceAtual()
        {
            //Arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);

            detalhePO.Visitar(1);

            //Act
            detalhePO.OfertarLeilao(300);

            //Assert
            //wait explícito onde criamos o wait de 8 segundos
            // depois criamos uma variável bool e usamos o wait.Until que valida se é true ou false
            // o resultado de uma função até o time out informado.
            // a função avalidada é uma expressão lambada que verifica se o valor valor de lanceAtual
            // é igual a 300
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
