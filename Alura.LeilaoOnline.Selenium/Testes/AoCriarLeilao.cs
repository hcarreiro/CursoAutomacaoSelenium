﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("admin@example.org")
                .InformarSenha("123")
                //act
                .SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
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
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
