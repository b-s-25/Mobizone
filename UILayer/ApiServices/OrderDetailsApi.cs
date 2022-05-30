using DomainLayer;
using DomainLayer.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.ApiServices
{
    public class OrderDetailsApi
    {
        string _url;
        IConfiguration _configuration;
        public OrderDetailsApi(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("Development")["BaseApi"].ToString();
        }
        public IEnumerable<UserCheckOut> GetOderDetails()
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/Orderdetails/Orderdetails";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserCheckOut>>(response.Result);
                    return results;
                }
                return null;
            }

        }

        public UserCheckOut OrderDetailsGetById(int id)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44388/api/Orderdetails/Orderdetails" + id;
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<UserCheckOut>(serilizedResult.Result);
                    return products;
                }
                return null;
            }

        }



        public bool OrderDetailsEdit(UserCheckOut orderdetails)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(orderdetails);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/Orderdetails/OrderPut";
                Uri uri = new Uri(url);
                HttpResponseMessage response = httpclient.PutAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            }
        public bool OrderDetailsCreate(UserCheckOut orderdetails)
        {

            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(orderdetails);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/Orderdetails/Orderdetails";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PostAsync(uri, content);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //public bool Delete(int id)
        //{
        //    using (HttpClient httpclient = new HttpClient())
        //    {
        //        string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        string url = "https://localhost:44388/api/Orderdetails/ProductDelete/" + id;
        //        Uri uri = new Uri(url);
        //        System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.DeleteAsync(uri);

        //        if (response.Result.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}
    }
}
