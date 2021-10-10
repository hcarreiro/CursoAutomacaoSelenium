using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            new RegistroPO(driver)
                .Visitar()
                .InformarNome("Hildefonso Carreiro")
                .InformarEmail("hildefonso.carreiro@t2mlab.com")
                .InformarSenha("123")
                .InformarConfirmSenha("123")
                .SubmeteFormulario();

            //assert
            Assert.Contains("Obrigado", driver.PageSource);

        }

        //Theory diz que a teoria será a mesma para a execução de testes similares
        [Theory]
        //InlineData seta o pull da dados para execução do teste cada linha é um teste
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Daniel Portugal", "daniel", "123", "123")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        //Informar as variáveis como parâmetros no método do inlinedata
        public void DadoInfoinvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange
            new RegistroPO(driver)
                .Visitar()
                .InformarNome(nome)
                .InformarEmail(email)
                .InformarSenha(senha)
                .InformarConfirmSenha(confirmSenha)
                //act
                .SubmeteFormulario();

            //assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert - 
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            new RegistroPO(driver)
                .Visitar()
                .InformarNome("")
                .InformarEmail("hildefonso")
                .InformarSenha("")
                .InformarConfirmSenha("")
                //act
                .SubmeteFormulario();

            //assert
            RegistroPO regPO = new RegistroPO(driver);
            Assert.Equal("Please enter a valid email address.", regPO.EmailMensagemErro);
        }
    }
}
