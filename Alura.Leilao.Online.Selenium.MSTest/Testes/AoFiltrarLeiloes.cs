using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoFiltrarLeiloes : TestInitialize
    {
        [TestMethod]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            var dashboardInteressadaPO = new DashboardInteressadaPO(Driver);

            //act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Resultado da pesquisa"));
        }
    }
}
