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
            Assert.AreEqual(title, _driver.Title);
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
        [TestMethod]
        public void TestPageElements()
        {

            _driver.Navigate().GoToUrl("https://ecosaver.azurewebsites.net/");


            IWebElement energyCard = _driver.FindElement(By.CssSelector("div.card-body > h5.card-title"));
            Assert.AreEqual("Vælg by for vejrudsigten*", energyCard.Text);
           
            IWebElement energyButton = _driver.FindElement(By.CssSelector("div.card-body > button.btn"));
            Assert.AreEqual("Vis vejr", energyButton.Text);

           
            // Verify the "Vejr i {{locationCity}}" card
            IWebElement weatherCard = _driver.FindElements(By.CssSelector("div.card-body > h5.card-title"))[1];
            Assert.AreEqual("Vælg tidspunkt", weatherCard.Text);

            IWebElement temperatureElement = _driver.FindElement(By.XPath("//p[contains(text(), 'Temperatur:')]"));
            Assert.IsTrue(temperatureElement.Text.Contains("Temperatur:"));

            IWebElement humidityElement = _driver.FindElement(By.XPath("//p[contains(text(), 'Fugtighed:')]"));
            Assert.IsTrue(humidityElement.Text.Contains("Fugtighed:"));

            IWebElement outdoorDryElement = _driver.FindElement(By.XPath("//p[contains(text(), 'Udendørs tøjophæng?')]"));
            Assert.IsTrue(outdoorDryElement.Text.Contains("Udendørs tøjophæng?"));

            IWebElement weatherButton = _driver.FindElement(By.CssSelector("div.card-body > button.btn"));
            Assert.AreEqual("Vis vejr", weatherButton.Text);
                       

            IWebElement powerHistoryCard = _driver.FindElements(By.CssSelector("div.card-body > h5.card-title"))[2];
            Assert.AreEqual("Gennemsnit pris for i dag", powerHistoryCard.Text);


            IWebElement averagePriceDay1 = _driver.FindElement(By.XPath("//p[contains(text(), 'Gennemsnit for 0 dage siden:')]"));
            Assert.IsTrue(averagePriceDay1.Text.Contains("Gennemsnit for 0 dage siden:"));

            IWebElement averagePriceDay2 = _driver.FindElement(By.XPath("//p[contains(text(), 'Gennemsnit for 1 dage siden:')]"));
            Assert.IsTrue(averagePriceDay2.Text.Contains("Gennemsnit for 1 dage siden:"));
        }

    }
}