using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoEfetuarRegistro : TestInitialize
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            new RegistroPO(Driver)
                .Visitar()
                .InformarNome("Hildefonso Carreiro")
                .InformarEmail("hildefonso.carreiro@t2mlab.com")
                .InformarSenha("123")
                .InformarConfirmSenha("123")
                .SubmeteFormulario();

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Obrigado"));

        }

        [DataTestMethod]
        [DataRow("", "daniel.portugal@caelum.com.br", "123", "123")]
        [DataRow("Daniel Portugal", "daniel", "123", "123")]
        [DataRow("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [DataRow("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInfoinvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange
            new RegistroPO(Driver)
                .Visitar()
                .InformarNome(nome)
                .InformarEmail(email)
                .InformarSenha(senha)
                .InformarConfirmSenha(confirmSenha)
                //act
                .SubmeteFormulario();

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("section-registro"));
        }

        [TestMethod]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(Driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert - 
            Assert.AreEqual("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [TestMethod]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            new RegistroPO(Driver)
                .Visitar()
                .InformarNome("")
                .InformarEmail("hildefonso")
                .InformarSenha("")
                .InformarConfirmSenha("")
                //act
                .SubmeteFormulario();

            //assert
            RegistroPO regPO = new RegistroPO(Driver);
            Assert.AreEqual("Please enter a valid email address.", regPO.EmailMensagemErro);
        }
    }
}
