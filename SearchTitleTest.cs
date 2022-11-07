using NUnit.Framework.Interfaces;

namespace Google.UI.Test
{
    [TestFixture]
    internal class SearchTitleTest
    {
        private IWebDriver _driver;
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            // scoped logger instanciation
            using ILoggerFactory loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
            _logger = loggerFactory.CreateLogger<SearchTitleTest>();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void GoogleSearch()
        {
            string queryString = "Hello World";
            _driver.Navigate().GoToUrl(Navigations._url);

            // find elements
            IWebElement searchBar = _driver.FindElement(By.Name(Navigations._NameSearchQuery));
            IWebElement searchButton = _driver.FindElement(By.Name(Navigations._NameSearchButton));

            // send query text
            searchBar.SendKeys(queryString);

            //make a query
            searchButton.Click();

            // get page title
            var PageTitle = _driver.Title;
            _logger.LogInformation(PageTitle);
        }
    }
}
