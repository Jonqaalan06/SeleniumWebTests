using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebTests.APITests;
using SeleniumWebTests.APITests.DTOs;
using SeleniumWebTests.PageClasses;

namespace SeleniumWebTests.Tests
{
    public class FamilyMemberListTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public FamilyMembersListPage FMPage { get; set; }

        public FamilyMemberListTests() 
        {
            _driver = new ChromeDriver();
            FMPage = new FamilyMembersListPage(_driver);
        }

        [Fact]
        public void FamilyMemberUrlValidation()
        {
            Assert.Contains("FamMembers", FMPage.PageUrl);
        }

        [Fact]
        public async void CanAddFamilyMemberApiRequest() 
        {
            var familyMember = new FamilyMemberDto { FirstName = "John", LastName = "Smith", MiddleName = "Danger" };
            var api = new ApiBase();
            var response = await api.CallAddFamilyMemberApi(familyMember);
            Assert.True(response);

        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
