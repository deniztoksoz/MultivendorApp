using MultivendorAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorAPP.Services
{
    public class Auth : IAuth
    {

        private string base_url = "http://multivendorapi.azurewebsites.net/api/";

        public async Task<Token> Login(string email, string password)
        {
            string url = base_url + "auth/login";

            Token login = new Token();
            login.Email = email;
            login.Password = password;

            var json = JsonConvert.SerializeObject(login);

            HttpClient client = new HttpClient();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url,content);

            string result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonResult = JsonConvert.DeserializeObject<Token>(result);
                return JsonResult;
            }


            return null;
        }



        public async Task<bool> Register(Register user)
        {
            string url = base_url + "auth/register";


            var json = JsonConvert.SerializeObject(user);

            HttpClient client = new HttpClient();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }


            return false;
        }
    }
}
