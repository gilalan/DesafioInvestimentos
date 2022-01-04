using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioInvestimentos.Models
{
    public static class AcaoConsultas
    {
        public static async Task<YahooResponse> ObterCotacaoAsync(string symbol)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://yfapi.net/");
                    httpClient.DefaultRequestHeaders.Add("X-API-KEY",
                        "OWnLsCyj8u4UsGzvnigNPadyRwwowAv673JLqfP0");
                    httpClient.DefaultRequestHeaders.Add("accept",
                        "application/json");

                    var response = await httpClient.GetAsync(
                        $"v6/finance/quote?lang=en&region=US&symbols={symbol}");
                    var responseBody = await response.Content.ReadAsStringAsync();
                    YahooResponse result = JsonConvert.DeserializeObject<YahooResponse>(responseBody);
                    return result;
                }
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
