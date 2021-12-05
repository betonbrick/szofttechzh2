using System;
using CarPartsMobileApp.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarPartsMobileApp.Data
{
    public class RestAPIService
    {
        HttpClient httpclient;

        string grantType = "password";

        public RestAPIService()
        {
            httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-form-urlencoded"));
            httpclient.MaxResponseContentBufferSize = 30000;
        }

        

        public async Task<T> postResponse<T>(string url, string jsonstr) where T : class 
        {
            Tokenz tokenz = App.TokenzDB.GetTokenz();
            string contType = "application/json";
            httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",tokenz.accToken);

            try
            {
                HttpResponseMessage respresult = await httpclient.PostAsync(url, new StringContent(jsonstr, Encoding.UTF8, contType));
                if (respresult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonRes = respresult.Content.ReadAsStringAsync().Result;

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonRes);
                    }
                    catch 
                    {

                        return null;
                    }
                }
            }
            catch 
            {

                return null;
            }
            return null;
        }

        public async Task<T>GetResp<T>(string url) where T: class 
        {
            Tokenz tokenz = App.TokenzDB.GetTokenz();
            httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenz.accToken);

            try
            {
                HttpResponseMessage response = await httpclient.GetAsync(url);
                if (response.StatusCode== System.Net.HttpStatusCode.OK)
                {
                    string jsonRes = response.Content.ReadAsStringAsync().Result;

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonRes);
                    }
                    catch 
                    {

                        return null;
                    }
                }
            }
            catch 
            {

                return null;
            }
            return null;
        }

        public async Task<Tokenz> login(loginUser user) 
        {
            List<KeyValuePair<string, string>> postdata = new List<KeyValuePair<string, string>>();

            postdata.Add(new KeyValuePair<string, string>("grant_type", grantType));
            postdata.Add(new KeyValuePair<string, string>("username", user.Username));
            postdata.Add(new KeyValuePair<string, string>("password", user.Password));

            FormUrlEncodedContent cont = new FormUrlEncodedContent(postdata);

            Tokenz response = await postResplogin<Tokenz>(Const.loginurl, cont);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expireDt = dt.AddSeconds(response.expireIn);
            return response;
        }

        public async Task<T> postResplogin<T>(string url, FormUrlEncodedContent cont) where T : class 
        {
            HttpResponseMessage response = await httpclient.PostAsync(url, cont);
            string res = response.Content.ReadAsStringAsync().Result;
            T deserialize = JsonConvert.DeserializeObject<T>(res);
            return deserialize;
        }


    }
}
