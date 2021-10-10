using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            //Passado o CssSelecto como filho direto de form sendo uma tag button com class contendo btn
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();

            //Agora vamos varrer as listas de opções e marcar as opções que queremos no nosso teste
            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);
            });

            //Informa o valor do termo recebido por parâmetro
            driver.FindElement(byInputTermo).SendKeys(termo);

            //Se emAndamento for true ele entra no if e realiza o click no elemento
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }
            driver.FindElement(byBotaoPesquisar).Click();
        }

    }
}
