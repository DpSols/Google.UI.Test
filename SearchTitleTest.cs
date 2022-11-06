using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Google.UI.Test
{
    [TestFixture]
    internal class SearchTitleTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void GoogleSearch()
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            
            _driver.Navigate().GoToUrl(Navigations._url);
            _driver.FindElement(By.ClassName(Navigations._classNameSearchQuery)).SendKeys("Hello World");
            _driver.FindElement(By.ClassName(Navigations._classNameSearchButton)).Click();
            var PageTitle = _driver.Title;
            logger.LogInformation(PageTitle);
        }
    }
}
