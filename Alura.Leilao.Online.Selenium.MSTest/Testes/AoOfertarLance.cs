using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoOfertarLance : TestInitialize
    {
        [TestMethod]
        public void DadoLoginInteressadaDeveOfertarLanceAtual()
        {
            //Arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(Driver);

            detalhePO.Visitar(1);

            //Act
            detalhePO.OfertarLeilao(300);

            //Assert
            //wait explícito onde criamos o wait de 8 segundos
            // depois criamos uma variável bool e usamos o wait.Until que valida se é true ou false
            // o resultado de uma função até o time out informado.
            // a função avalidada é uma expressão lambada que verifica se o valor valor de lanceAtual
            // é igual a 300
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.IsTrue(iguais);
        }
    }
}
