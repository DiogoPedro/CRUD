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
}