﻿using APILayer.Models;
using DomainLayer;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.ApiServices
{
    public class AdminApi
    {
        public bool AdminLogin(Login userLogin)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(userLogin);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44388/api/User/AdminLogin";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }

        public  IEnumerable<Registration> GetUserData()
        {
            IEnumerable<Registration> userdata = new List<Registration>();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://localhost:44388/api/UserData/GetUserData";
                Uri uri = new Uri(url);
                Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
                    userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Registration>>(serilizedResult.Result);
                }
            }
            return userdata;
        }
    }
}
