using APILayer.Models;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UILayer.ApiServices
{
    public class Masterdataapi
    {
        public IEnumerable<MasterData> MasterDatas()
        {

            UserResponse<IEnumerable<MasterData>> _responseModel = new UserResponse<IEnumerable<MasterData>>();
            using (HttpClient httpclient = new HttpClient())
            {

                string url = "https://localhost:44380/api/Masterdata/GetMasterData";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel.result = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MasterData>>(response.Result);
                }

                return _responseModel.result;
            }
        }
        //public static IEnumerable<MasterData> GetAll()
        //{
        //    IEnumerable<MasterData> masterDatas = new List<MasterData>();

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        string url = "https://localhost:44364/api/Masterdata/GetMasterData";
        //        Uri uri = new Uri(url);
        //        Task<HttpResponseMessage> result = httpClient.GetAsync(uri);
        //        if (result.Result.IsSuccessStatusCode)
        //        {
        //            Task<string> serilizedResult = result.Result.Content.ReadAsStringAsync();
        //            masterDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MasterData>>(serilizedResult.Result);
        //        }

        //    }
        //    return masterDatas;

        //}
        public bool EditMasterData(MasterData MasterData)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(MasterData);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44380/api/Masterdata/MasterDataPut";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PutAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
        public bool MasterDataAdd(MasterData masterdata)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(masterdata);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "https://localhost:44380/api/MasterData/MasterDataPost";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
