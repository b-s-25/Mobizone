using DomainLayer;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.Datas.Apiservices
{
    public class ProductApi
    {

        IConfiguration _configuration;
        public ProductApi()
        {

        }
        public static IEnumerable<Products> index()

        {

            IEnumerable<Products> products = new List<Products>();

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44388/api/ProductCatagory/Index";
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    products = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Products>>(serilizedResult.Result);
                }

            }
            return products;

        }

        public static Products GetById(int id)
        {
            Products products = new Products();

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44388/api/ProductCatagory/ProductCatagory/Details/{id}" + id;
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    products = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(serilizedResult.Result);
                    return products;
                }
                return null;
            }

        }



        public static bool Edit(Products product)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/ProductCatagory/ProductPut";
                Uri uri = new Uri(url);
                HttpResponseMessage response = httpclient.PutAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public static bool Create(Products product)
        {

            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/ProductCatagory/ProductPost";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PostAsync(uri, content);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool Delete(int id)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/productcatagory/ProductDelete/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.DeleteAsync(uri);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public static IEnumerable<Specification> Index()

        {

            IEnumerable<Specification> specification = new List<Specification>();

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44364/api/SpecOperation/Index";
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    specification = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Specification>>(serilizedResult.Result);
                }

            }
            return specification;
        }
        public static Specification ById(int id)
        {
            Specification specification = new Specification();

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44364/api/SpecOperation/Details/{id}" + id;
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    specification = Newtonsoft.Json.JsonConvert.DeserializeObject<Specification>(serilizedResult.Result);
                    return specification;
                }
                return null;
            }

        }



        public static bool Edit(Specification specification)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(specification);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/SpecOperation/SpecPut";
                Uri uri = new Uri(url);
                HttpResponseMessage response = httpclient.PutAsync(uri,content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }



        public static bool Create(Specification specification)
        {

            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(specification);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/SpecOperation/SpecPost";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PostAsync(uri, content);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }



        public static bool SpeDelete(int id)
        {


            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44364/api/SpecOperation/SpecDelete/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.DeleteAsync(uri);

                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
