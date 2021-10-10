﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.Leilao.Online.Selenium.MSTest.Helpers
{
    public class LinksDeAcesso
    {
        public static string PaginaHome => "http://localhost:5000";
        public static string PaginaInclusaoLeilao => "http://localhost:5000/Leiloes/Novo";
        public static string PaginaLeilaoEmAndamento => "http://localhost:5000/Home/Detalhes/";
        public static string PaginaLogin => "http://localhost:5000/Autenticacao/Login";

    }
}
