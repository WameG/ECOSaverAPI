using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Webdrivers";
        private static IWebDriver _driver;


        [ClassInitialize]

        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }
        [ClassCleanup]
        public static void Cleanup()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void SelectCity_ShouldDisplaySelectedCity()
        {
            string url = "https://ecosaver.azurewebsites.net/";
            _driver.Navigate().GoToUrl(url);
            string title = _driver.Title;
            Assert.AreEqual(title,_driver.Title);
            IWebElement SelectCity = _driver.FindElement(By.CssSelector("select.form-select"));
            SelectElement select = new SelectElement(SelectCity);
            select.SelectByText("Copenhagen");


            IWebElement cityText = _driver.FindElement(By.CssSelector("p.card-text"));
            Assert.AreEqual("By: Copenhagen", cityText.Text);
        }
        [TestMethod]
        public void ShowWeather_ShouldDisplaýTemperatureAndDescription()
        {
            _driver.Navigate().GoToUrl("https://ecosaver.azurewebsites.net/");
            IWebElement CitySelect = _driver.FindElement(By.CssSelector("select.form-select"));
            SelectElement select = new SelectElement(CitySelect);
            select.SelectByText("Copenhagen");

            IWebElement weatherButton = _driver.FindElement(By.CssSelector("button.btn-primary"));
            weatherButton.Click();

            IWebElement temperatureText = _driver.FindElement(By.XPath("//p[contains(text(),'Temperatur')]"));
            IWebElement descriptionText = _driver.FindElement(By.XPath("//p[contains(text(),'Beskrivelse')]"));

            Assert.IsTrue(temperatureText.Text.Contains("Temperatur"));
            Assert.IsTrue(descriptionText.Text.Contains("Beskrivelse"));
        }
    }
}