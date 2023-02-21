using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SeleniumWebTests.APITests.DTOs;
using Newtonsoft.Json;

namespace SeleniumWebTests.APITests
{
    public class ApiBase
    {
        public async Task<bool> CallAddFamilyMemberApi(FamilyMemberDto familyMember)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7202/");
                var jsonContent = new StringContent(JsonConvert.SerializeObject(familyMember), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("FamilyMemberApiController/AddFamilyMember", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            
        }

    }
}
