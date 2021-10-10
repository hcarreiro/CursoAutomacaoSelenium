using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using OpenQA.Selenium;

namespace Alura.Leilao.Online.Selenium.MSTest.PageObjects
{
    class RegistroPO
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErroEmail;
        private By bySpanErroNome;

        /*Criação de um atributo EmailMensagemErro e usando uma expressão lambda pra ele já retornar o valor desejado ao invés de 
        usar get e set. */
        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
        }

        public RegistroPO Visitar()
        {
            driver.Navigate().GoToUrl(LinksDeAcesso.PaginaHome);
            return this;
        }

        public RegistroPO InformarNome(string nome)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            return this;
        }
        public RegistroPO InformarEmail(string email)
        {
            driver.FindElement(byInputEmail).SendKeys(email);
            return this;
        }
        public RegistroPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }
        public RegistroPO InformarConfirmSenha(string confirmSenha)
        {
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
            return this;
        }

        public RegistroPO SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
            return this;
        }
    }
}
