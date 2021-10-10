using OpenQA.Selenium;

namespace Alura.Leilao.Online.Selenium.MSTest.PageObjects
{
    class DashboardInteressadaPO
    {
        private IWebDriver driver;

        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }
    }
}
