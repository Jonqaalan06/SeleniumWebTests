using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebTests.PageClasses
{
    public class GoogleHomePage
    {
        IWebDriver _webDriver;
        public GoogleHomePage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Navigate().GoToUrl("https://www.google.com");
            _webDriver.Manage().Window.Maximize();
        }

        public IWebElement SearchBar => _webDriver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input"));

        public List<IWebElement> GoogleSearchBtn => _webDriver.FindElements(By.ClassName("gNO89b")).ToList();

        public void ClickGoogleSearchButton()
        {
            foreach (var btn in GoogleSearchBtn)
            {
                if (btn.Displayed)
                {
                    btn.Click();
                    break;
                }
            }
        }
        public void EnterSearchString(string searchString)
        {
            SearchBar.SendKeys(searchString);
        }

    }
}
