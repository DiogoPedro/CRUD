using MyApplication.Services;
using MyApplication.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

public class SegmentService
{
    private HttpClient _httpClient;
    private string _SecretKey;
    private string _Route;
    public SegmentService(HttpClient httpClient, Configuration configuracao)
    {
        _SecretKey = configuracao._SecretKey;
        _Route = configuracao.RouteSegments;
        httpClient.BaseAddress = new Uri(configuracao.UrlBase);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _SecretKey);
        _httpClient = httpClient;
    }

    public async Task<Segment> RetornarRota()
    {
        var client = new HttpClient();  
        var response = await client.GetAsync(_httpClient.BaseAddress + _Route + "?apiKey=" + _SecretKey);
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
        var response = await client.GetAsync(_httpClient.BaseAddress + _Route + link);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<ItemSegment>(content);
        }
        return null;
    }

    public async Task<bool> AttItem(string id, ItemSegment itemSegment)
    {
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();  
        var json = JsonConvert.SerializeObject(itemSegment);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(_httpClient.BaseAddress + _Route + link, jsonContent);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return true;
        }
        return false;       
    }

    public async Task<bool> RemoveItem(string id)
    { 
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();  
        var response = await client.DeleteAsync(_httpClient.BaseAddress + _Route + link);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return true;
        }
        return false;
    }

    public async Task<string> CreateItem(NewSegment newSegment)
    { 
        string obj = JsonConvert.SerializeObject(newSegment);
        var content = new StringContent(obj, Encoding.UTF8, "application/json");
        
        var client = new HttpClient();
        var response = await client.PostAsync(_httpClient.BaseAddress + _Route + "?apiKey=" + _SecretKey, content); 
        //var response = await client.PostAsync("?apiKey=" + _SecretKey, content);
        if(response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            if(result != null)
                return result;
        }
        return "";
    }

    public async Task<string> ReturnNameSegment(string id)
    { 
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();  
        var response = await client.GetAsync(_httpClient.BaseAddress + _Route + link);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<ItemSegment>(content).Nome;
        }
        return "";
    }
}
