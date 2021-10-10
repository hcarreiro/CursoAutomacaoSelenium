using Alura.Leilao.Online.Selenium.MSTest.Helpers;
using Alura.Leilao.Online.Selenium.MSTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alura.Leilao.Online.Selenium.MSTest.Testes
{
    [TestClass]
    public class AoCriarLeilao : TestInitialize
    {
        [TestMethod]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            new LoginPO(Driver)
                .Visitar()
                .InformarEmail("admin@example.org")
                .InformarSenha("123")
                //act
                .SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(Driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Nullam aliquet condimentum elit vitae volutpat. Vivamus ut nisi venenatis, facilisis odio eget, lobortis tortor. Cras mattis sit amet dolor id bibendum. Nulla turpis justo, porttitor eget leo vel, dictum tempor diam. Sed dui arcu, feugiat nec placerat ac, suscipit a mi. Etiam eget risus et tellus placerat tincidunt at ut lorem.",
                "Item de Colecionador",
                4000,
                "C:\\Users\\HildefonsoDutraCarre\\Downloads\\moto.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
            );

            //act
            novoLeilaoPO.SubmeteFormulario();

            //assert
            Assert.IsTrue((Driver.PageSource ?? "").Contains("Leilões cadastrados no sistema"));
        }
    }
}
