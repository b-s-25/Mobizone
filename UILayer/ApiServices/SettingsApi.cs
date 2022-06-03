using APILayer.Models;
using DomainLayer.AdminSettings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.ApiServices
{
    public class SettingsApi
    {
        private IConfiguration _configuration { get; }
        string _url;
        public SettingsApi(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("Development")["BaseApi"].ToString();
        }

        public bool CreateAbout(About about)
        {
                using (HttpClient httpclient = new HttpClient())
                {
                    string data = Newtonsoft.Json.JsonConvert.SerializeObject(about);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    string url = _url + "/api/AdminSettings/AboutPost";
                    Uri uri = new Uri(url);
                    System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                    if (result.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                    return false;
                }
        }

        public bool CreateContact(Contact contact)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(contact);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = _url + "/api/AdminSettings/ContactPost";

                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<About> GetAbout()
        {
            UserResponse<IEnumerable<About>> _responseModel = new UserResponse<IEnumerable<About>>();
            using (HttpClient httpclient = new HttpClient())
            {

                string url = _url + "api/AdminSettings/AboutGet";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel.result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<About>>(response.Result);
                }
                return _responseModel.result;
            }
        }

        public IEnumerable<Contact> GetContact()
        {
            UserResponse<IEnumerable<Contact>> _responseModel = new UserResponse<IEnumerable<Contact>>();
            using (HttpClient httpclient = new HttpClient())
            {

                string url = _url + "/api/AdminSettings/ContactGet";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel.result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Contact>>(response.Result);
                }
                return _responseModel.result;
            }
        }

        public bool EditAbout(About about)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(about);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = _url + "api/AdminSettings/AboutPut";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PutAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public bool EditContact(Contact contact)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(contact);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = _url + "/api/AdminSettings/ContactPut";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PutAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
