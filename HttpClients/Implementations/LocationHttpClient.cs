using System.Net.Http.Json;
using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class LocationHttpClient : ILocationService
{
    
    private readonly HttpClient client;

    public LocationHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task saveLocation(Location location)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Location/create",location);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<Location>> findAll()
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Location/GetAll");
        string result = await response.Content.ReadAsStringAsync();
        bool status = response.IsSuccessStatusCode;
        Console.WriteLine(status);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Location> locations = JsonSerializer.Deserialize<IEnumerable<Location>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return locations;
    }

    public async Task<Location> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Location/GetById/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Location location = JsonSerializer.Deserialize<Location>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return location;
    }
}