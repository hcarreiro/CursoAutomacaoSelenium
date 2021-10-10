using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoNavegarParaFormNovoLeilao : TestInitialize
    {
        [TestMethod]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange
            //arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("admin@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(Driver);

            //act
            novoLeilaoPO.Visitar();

            //assert
            Assert.AreEqual(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
