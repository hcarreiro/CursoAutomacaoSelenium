using OpenQA.Selenium.Chrome;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class ConfigTesteMobile
    {
        public ChromeOptions EmularMobile(
            int width,
            int height,
            string userAgent)
        {
            //Realizar a criação de configuração de um driver emulando o
            //acesso mobile
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = width;
            deviceSettings.Height = height;
            deviceSettings.UserAgent = userAgent;

            //Crio uma variável do tipo ChromeOptions que receberá as configurações deviceSettings
            var options = new ChromeOptions();
            //Passo para options que a emulaçao mobile está ativa e os parâmetros de inicialização
            options.EnableMobileEmulation(deviceSettings);

            return options;
        }
    }
}
