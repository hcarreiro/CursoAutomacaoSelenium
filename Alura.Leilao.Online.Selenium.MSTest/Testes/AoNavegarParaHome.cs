using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoNavegarParaHome : TestInitialize
    {
        [TestMethod]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange

            //act
            Driver.Navigate().GoToUrl(LinksDeAcesso.PaginaHome);

            //assert
            Assert.AreEqual("Leilões Online", Driver.Title);
        }

        [TestMethod]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            Driver.Navigate().GoToUrl(LinksDeAcesso.PaginaHome);

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Próximos Leilões"));
        }

        [TestMethod]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //arrange

            //act
            Driver.Navigate().GoToUrl(LinksDeAcesso.PaginaHome);

            //assert
            /*Na minha página tenho apenas uma tag form que é o formulário de cadastro, 
             * então posso usar a tag "form" para pegar todo o conteúdo desta tag */
            var form = Driver.FindElement(By.TagName("form"));

            /*Crio uma coleção chamada spans e uso o FindElements com 's' para pegar todos
             * os valores com a tagName passada como parâmetro */
            var spans = form.FindElements(By.TagName("span"));

            /*Uso um foreach para varrer cada span da minha coleção e verificar se o span
             não está visível:
             Assert.False(span.Displayed);
             -- Esse teste daria erro porque o span sempre está visível, é a caixa e não o texto*/

            foreach (var span in spans)
            {
                //Esta validação verifica agora se o texto dentro da tag span está vazio ou nulo
                Assert.IsTrue(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
