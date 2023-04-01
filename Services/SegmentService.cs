namespace MyApplication.Services;
using System.Net.Http.Headers;
using Newtonsoft.Json;
public class SegmentService
{
    private HttpClient _httpClient;
    public SegmentService(HttpClient httpClient, Configuration configuracao)
    {
        httpClient.BaseAddress = new Uri(configuracao.UrlBase);
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "6425f48dd90328e7c643c5a0");
        _httpClient = httpClient;
    }

    public async Task<Segment> RetornarRota()
    {
        //this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apiKey", "6425f48dd90328e7c643c5a0");
        var response = await this._httpClient.GetAsync("?apiKey=6425f48dd90328e7c643c5a0");
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<Segment>(content);
        }
        return new Segment();
    }

    //https://nocodebackend-nocodebackend-stage.azurewebsites.net/api/v1/dataset/642745c1d90328e7c643cd66/611edbd7fd5915f2ae005dc2/{id}?apiKey=6425f48dd90328e7c643c5a0 

    public async Task<ItemSegment> ReturnItem(int id)
    {
        //this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apiKey", "6425f48dd90328e7c643c5a0");
        string route = id.ToString() + "?apiKey=6425f48dd90328e7c643c5a0";    
        var response = await this._httpClient.GetAsync(route);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<ItemSegment>(content);
        }
        return new ItemSegment();
    }

    public async Task<Segment> Main()
    {
        var client = new HttpClient();
        var url = "https://nocodebackend-nocodebackend-stage.azurewebsites.net/api/v1/dataset/642745c1d90328e7c643cd66/611ed902fd5915f2ae005dbb?apiKey=6425f48dd90328e7c643c5a0";

        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var sla = RetornarRota();
            var x = content;
            return JsonConvert.DeserializeObject<Segment>(content);
        }
        else
        {
            return new Segment();
        }
    }

}
