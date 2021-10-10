using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoEfetuarLogin : TestInitialize
    {
        [TestMethod]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            /*Crio um objeto do tipo LoginPO e faço uma injeção de dependências nela passando o driver
             pois ela realizará processos que necessitam de um driver*/
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                //act
                .SubmeteFormulario();

            //assert
            Assert.AreEqual("Dashboard", Driver.Title);
        }

        [TestMethod]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            //arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("")
                .SubmeteFormulario();

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Login"));
        }
    }
}
