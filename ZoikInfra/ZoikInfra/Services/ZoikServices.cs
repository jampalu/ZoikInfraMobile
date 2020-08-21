using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ZoikInfra.Models;

namespace ZoikInfra.Services
{
    public class ZoikServices
    {
        HttpClient client;
        public ZoikServices()
        {
            client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer "+"");
        }
        public async System.Threading.Tasks.Task<string> LoginAsync(User user)
        {
            var WebAPIUrl = "http://novelskihyd-001-site3.itempurl.com/api/Token";
            //Set your REST API URL here.

            var uri = new Uri(WebAPIUrl);

            try
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, data);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    App._token = "Bearer " + content;
                    //Items = JsonConvert.DeserializeObject<ObservableCollection>(content);
                    return content;
                }
            }
            catch (Exception ex)
            {
            }
            return null;

        }
        public async System.Threading.Tasks.Task<List<Item>> GetCustomerVisits()
        {
            var WebAPIUrl = "http://novelskihyd-001-site3.itempurl.com/api/CustomerVisits";
            client.DefaultRequestHeaders.Add("Authorization", App._token);
            //Set your REST API URL here.

            var uri = new Uri(WebAPIUrl);

            try
            {
                //var json = JsonConvert.SerializeObject(user);
                //var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //App._token = "Bearer " + content;
                    //Items = JsonConvert.DeserializeObject<ObservableCollection>(content);
                    List<Item> itemlst = JsonConvert.DeserializeObject<List<Item>>(content);
                    return itemlst;
                }
            }
            catch (Exception ex)
            {
            }
            return null;

        }
    }
}
