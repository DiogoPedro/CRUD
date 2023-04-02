using MyApplication.Services;
using MyApplication.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class SegmentService
{
    private HttpClient _httpClient;
    private string _SecretKey;
    public SegmentService(HttpClient httpClient, Configuration configuracao)
    {
        _SecretKey = configuracao._SecretKey;
        httpClient.BaseAddress = new Uri(configuracao.UrlBase);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _SecretKey);
        _httpClient = httpClient;
    }

    public async Task<Segment> RetornarRota()
    {
        var response = await this._httpClient.GetAsync("?apiKey=" + _SecretKey);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<Segment>(content);
        }
        return new Segment();
    }

    public async Task<ItemSegment> ReturnItem(string id)
    { 
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();  
        var response = await client.GetAsync(_httpClient.BaseAddress + link);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<ItemSegment>(content);
        }
        ItemSegment dsa = new ItemSegment();
        dsa.Nome = "";
        return null;
    }
}
