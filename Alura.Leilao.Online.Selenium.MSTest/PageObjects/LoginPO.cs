using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using OpenQA.Selenium;

namespace Alura.Leilao.Online.Selenium.MSTest.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl(LinksDeAcesso.PaginaLogin);
            return this;
        }

        public LoginPO InformarEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }
        public LoginPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO SubmeteFormulario()
        {
            /*Posso usar o método submit ou click. Neste contexto posso usar submit porque o formulário em questão
            está dentro de uma tag <form> */
            driver.FindElement(byBotaoLogin).Submit();
            return this;
        }
    }
}
