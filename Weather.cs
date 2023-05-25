using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WheatherApp
{
    public class Weather
    {
        private string _city;
        private string _api;
        private dynamic _currentWeather;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
            }
        }
        public string API
        {
            get => _api;
            set
            {
                _api = value;
            }
        }
        public dynamic CurrentWeather
        {
            get => _currentWeather;
            set
            {
                _currentWeather = value;
            }
        }
        public async Task<bool> GetWeather()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{_city}?key={_api}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                return false;

            var body = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(body);

            _currentWeather = json;
            return true;
        }


    }


}
