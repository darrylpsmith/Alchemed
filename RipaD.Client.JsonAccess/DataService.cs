using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RipaD.Core;


namespace RipaD.Client.JsonAccess
{
    public class DataService
    {
        HttpClient _client = null;

        public DataService()
        {
            _client = new HttpClient();
        }
        public DataService(HttpClient client)
        {
            _client = client;
        }

        public async Task<dynamic> GetAsync(string queryString, List<string> propertiesToFilterOn)
        {
            var response = await _client.GetAsync(queryString);

            response.EnsureSuccessStatusCode();

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }

        private string GetQueryStringForEntity(object Entity, List<string> propertiesToFilterOn)
        {

            EntityDescriber describer = new EntityDescriber(Entity);
            var properties = describer.AllPropertyValues();

            string queryString = "Query=";
            int i = 0;
            bool filterSpecified = false;
            if (propertiesToFilterOn != null)
            {
                filterSpecified = true;
            }


            foreach (var property in properties)
            {
                var value = property.Value;
                bool includeThisProperty = false;

                if (filterSpecified)
                    includeThisProperty = propertiesToFilterOn.Contains(property.Name);
                else
                    includeThisProperty = true;

                if (value != null && includeThisProperty)
                {
                    queryString += i > 0 ? "|" : "";
                    queryString += $"{property.Name}={value}";
                    i++;
                }
            }

            return queryString;
        }
        public async Task<T> GetAsync <T> (string uri, string ApiKey, T entity, List<string> propertiesToFilterOn, bool returnsAlllist = false)
        {
            string strBody = JsonConvert.SerializeObject(entity);
            string entityType = entity.GetType().Name;
            string query = GetQueryStringForEntity(entity, propertiesToFilterOn);
            bool returnsArray = false;

            if (ApiKey.Length > 0)
            {
                uri += "/" + ApiKey;
            }

            if (returnsAlllist)
            {
                returnsArray = true;
                uri += "/" + entityType + (returnsAlllist ? "/ALL" : "") + "?" + query;
            }
            else if (propertiesToFilterOn != null)
            {
                returnsArray = true;
                uri += "/" + entityType + "/BYUQ" + "?" + query;
            }
            else
            {
                returnsArray = false;
                uri += "/" + entityType;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            //request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            //JObject data = null;
            T data;
            object ret;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                if (returnsArray == true)
                {
                    //data = JsonConvert.DeserializeObject<T>(json);
                    JArray ret2 = (JArray)JsonConvert.DeserializeObject<JArray>(json);
                    if (ret2.Count > 0)
                    {
                        ret = JsonConvert.DeserializeObject<T>(ret2[0].ToString());
                    }
                    else
                    {
                        ret = null;
                    }
                }
                else
                {
                    data = JsonConvert.DeserializeObject<T>(json);
                    ret = (T)data;
                }
            }
            else
            {
                ret = null;
            }

            return (T)ret;
        }

        public async Task<T> PostAsync <T>(string uri, string ApiKey, T entity)
        {

            string strBody = JsonConvert.SerializeObject(entity);
            string entityType = entity.GetType().Name;

            if (ApiKey.Length > 0)
            {
                uri += "/" + ApiKey;
            }
            
            uri += "/" + entityType;

            HttpResponseMessage response = null;

            if (entity != null)
            {
                StringContent bd = new StringContent(strBody);
                bd.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                response = await _client.PostAsync(uri, bd);
            }
            else
            {
                StringContent bd = new StringContent("");
                bd.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                response = await _client.PostAsync(uri, bd);
            }

            response.EnsureSuccessStatusCode();

            object data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data =  (T) JsonConvert.DeserializeObject<T>(json);
            }

            return (T) data;
        }



        //public static async Task<dynamic> PutAsync(string uri, string body)
        //{
        //    StringContent bd = new StringContent(body);
        //    bd.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    HttpClient client = new HttpClient();
        //    var response = await client.PutAsync(uri, bd);

        //    response.EnsureSuccessStatusCode();

        //    dynamic data = null;
        //    if (response != null)
        //    {
        //        string json = response.Content.ReadAsStringAsync().Result;
        //        data = JsonConvert.DeserializeObject(json);
        //    }

        //    return data;
        //}


        public async Task<dynamic> PutAsync(string uri, string apiKey, object entity)
        {
            string strBody = JsonConvert.SerializeObject(entity);
            string entityType = entity.GetType().Name;

            uri += "/" + apiKey;
            uri += "/" + entityType;

            StringContent bd = new StringContent(strBody);
            bd.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _client.PutAsync(uri, bd);

            response.EnsureSuccessStatusCode();

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
        public async Task<dynamic> DeleteAsync(string uri, string apiKey, object entity = null)
        {

            string strBody = JsonConvert.SerializeObject(entity);
            string entityType = entity.GetType().Name;

            uri += "/" + apiKey;
            uri += "/" + entityType;

            HttpClient client = new HttpClient();
            //var response = await client.DeleteAsync(uri,);

            var request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }


    }





}
