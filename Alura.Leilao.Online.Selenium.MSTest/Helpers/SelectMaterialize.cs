using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Leilao.Online.Selenium.MSTest.Helpers
{
    class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        //Crio uma coleção para conter os elementos
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            //Pego os elementos e seto na coleção
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        //Seria como se fosse um método que retorna o conjunto de opcoes já que a mesma é privada
        public IEnumerable<IWebElement> Options => opcoes;

        /*Método para abrir o dropdown list tornando o conteúdo visível*/
        private void OpenWrapper()
        {
            //Cliquei nele para ele exibir a lista tornando ela acessível
            selectWrapper.Click();
        }

        /*Método para dar um "tab" do teclado para tirar o foco do dropdown list*/
        private void LoseFocus()
        {
            //Fechar o wrapeer, tirar o foco dali
            //Pego um elemento li "qualquer" e dou um comando sendKeys que equivale ao tab do teclado
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }

        /*Método para deselecionar todas as opções da lista*/
        public void DeselectAll()
        {
            OpenWrapper();

            /*Ação de desmarcar todas as opções da lista*/
            //Como por padrão todas as opões vem marcadas, vamos fazer um foreach para clicar
            // e desmarcar todas elas
            opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });
            LoseFocus();
        }

        /*Método para receber a opção e marcar na lista*/
        public void SelectByText(string option)
        {
            OpenWrapper();

            /*Ação de procurar a opção recebida, procurar na lista e caso encontrada clicar*/
            //Varro as opções onde contém texto na categoria que vou passar por parâmetro e converto pra uma lista de conteúdo
            // texto das categorias
            opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                //Marcar a opção da lista
                .ForEach(o =>
                {
                    o.Click();
                });
            LoseFocus();
        }
    }
}
