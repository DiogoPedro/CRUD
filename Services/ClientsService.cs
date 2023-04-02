using MyApplication.Services;
using MyApplication.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

public class ClientsService
{
    private HttpClient _httpClient;
    private string _SecretKey;
    private string _Route;

    public ClientsService(HttpClient httpClient, Configuration configuracao)
    {
        _SecretKey = configuracao._SecretKey;
        _Route = configuracao.RouteClients;
        httpClient.BaseAddress = new Uri(configuracao.UrlBase);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _SecretKey);
        _httpClient = httpClient;      
    }

    public async Task<Clients> ReturnRoute()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(_httpClient.BaseAddress  + this._Route + "?apiKey=" + _SecretKey);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<Clients>(content);
        }
        return new Clients();
    }

    public async Task<DatumClients> ReturnItem(string id)
    {
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();
        var response = await client.GetAsync(_httpClient.BaseAddress  + this._Route + link);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return JsonConvert.DeserializeObject<DatumClients>(content);
        }
        return new DatumClients();
    }

    public async Task<bool> AttItem(string id, PutClient obj)
    {
        string link = $"{id}?apiKey={_SecretKey}"; 
        var client = new HttpClient();
        var json = JsonConvert.SerializeObject(obj);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(_httpClient.BaseAddress  + this._Route + link, jsonContent);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content != null)
                return true;
        }
        return false;
    }
}