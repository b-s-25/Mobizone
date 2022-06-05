﻿using APILayer.Models;
using DomainLayer;
using DomainLayer.Product;
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

        string _url;
        IConfiguration _configuration;
        public ProductApi(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("Development")["BaseApi"].ToString();
        }
        public IEnumerable<ProductsModel> GetProduct(int brand)
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/ProductCatagory";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductsModel>>(response.Result);
                    return results;
                }
                return null;
            }

        }

        public ProductsModel GetById(int id)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44388/api/ProductCatagory/ProductCatagory/Details/" + id;
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductsModel>(serilizedResult.Result);
                    return products;
                }
                return null;
            }

        }



        public  bool Edit(ProductsModel product)
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
        public  bool Create(ProductsModel product)
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

        public  bool Delete(int id)
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
        public IEnumerable<ProductsModel> ProductSearch(string name)
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/ProductCatagory/ProductSearch/"+name;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<IEnumerable<ProductsModel>>>(response.Result);
                    return results.Data;
                }
                return null;
            }

        }
        public async Task<IEnumerable<ProductsModel>> Filter(string name)
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/ProductCatagory/FilterByBrand";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductsModel>>(response.Result);
                    return results;
                }
                return null;
            }


        }
<<<<<<< HEAD
        public async Task<IEnumerable<ProductsModel>> SortByAscending(string price)
=======
        public async Task<IEnumerable<ProductsModel>> SortbyAscending(string price)
>>>>>>> d5e3a5c82540b37e29483e9b5b5e1074b060ecf8
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/ProductCatagory/SortByPriceAscending";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
<<<<<<< HEAD
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<IEnumerable<ProductsModel>>>(response.Result);
                    return results.Data;
=======
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductsModel>>(response.Result);
                    return results;
>>>>>>> d5e3a5c82540b37e29483e9b5b5e1074b060ecf8
                }
                return null;
            }


        }
<<<<<<< HEAD
        public async Task<IEnumerable<ProductsModel>> SortByDescending(string price)
=======
        public async Task<IEnumerable<ProductsModel>> SortbyDescending(string price)
>>>>>>> d5e3a5c82540b37e29483e9b5b5e1074b060ecf8
        {
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44388/api/ProductCatagory/SortByPriceDescending";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
<<<<<<< HEAD
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<IEnumerable<ProductsModel>>>(response.Result);
                    return results.Data;
=======
                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductsModel>>(response.Result);
                    return results;
>>>>>>> d5e3a5c82540b37e29483e9b5b5e1074b060ecf8
                }
                return null;
            }


        }
<<<<<<< HEAD

=======
>>>>>>> d5e3a5c82540b37e29483e9b5b5e1074b060ecf8
    }
}
