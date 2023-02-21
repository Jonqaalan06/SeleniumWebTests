using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebTests.PageClasses;

namespace SeleniumWebTests.Tests
{
    public class UnitTest1 : IDisposable
    {
        private readonly IWebDriver _driver;
        public GoogleHomePage GoogleHome { get; set; }

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            GoogleHome = new GoogleHomePage(_driver);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        [Fact]
        public void GoogleSearchUpdatesUrl()
        {
            GoogleHome.EnterSearchString("How to setup Selenium");
            GoogleHome.ClickGoogleSearchButton();


            Assert.Contains("How+to+setup+Selenium", _driver.Url);


        }
    }
}