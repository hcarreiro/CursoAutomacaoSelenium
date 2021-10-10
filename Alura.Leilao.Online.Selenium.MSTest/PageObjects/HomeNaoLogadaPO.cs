using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using OpenQA.Selenium;

namespace Alura.Leilao.Online.Selenium.MSTest.PageObjects
{
    class HomeNaoLogadaPO
    {
        private IWebDriver driver;
        public MenuNaoLogadoPO Menu { get; set; }

        public HomeNaoLogadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Menu = new MenuNaoLogadoPO(driver);
        }

        public HomeNaoLogadaPO Visitar()
        {
            driver.Navigate().GoToUrl(LinksDeAcesso.PaginaHome);
            return this;
        }
    }
}
