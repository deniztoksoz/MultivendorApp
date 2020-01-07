using MultivendorAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorAPP.Services
{
    public class Stokis : IStokis
    {


        private string base_url = "http://multivendorapi.azurewebsites.net/api/";
        public async Task<List<Users>> getStokis()
        {
            string url = base_url + "Users";

          

            HttpClient client = new HttpClient();


            HttpResponseMessage response = await client.GetAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonResult = JsonConvert.DeserializeObject<List<Users>>(result);
                return JsonResult;
            }


            return null;
        }
    }
}
