using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace Alura.Leilao.Online.Selenium.MSTest.Helpers
{
    public static class TestHelper
    {
        public static string pastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static ChromeOptions PastaDoExecutavel { get; internal set; }
    }
}
