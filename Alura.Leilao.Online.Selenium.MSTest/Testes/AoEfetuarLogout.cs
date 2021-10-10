using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoEfetuarLogout : TestInitialize
    {
        [TestMethod]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(Driver);

            //act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Próximos Leilões"));
        }
    }
}
