using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(User dto)
    {
        Console.WriteLine("CreateAsync method called");
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Users/create", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result)!;
        return user;
    }

    public async Task<User?> findById(int getById)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/{getById}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User? user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        Console.WriteLine("user");
        return user;
    }

    public async Task<User?> UpdateUser(User user)
    {
        Console.WriteLine("UpdateUser method called");
        HttpResponseMessage response = await client.PatchAsync("https://localhost:7093/Users/patch", new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        User updatedUser = JsonSerializer.Deserialize<User>(result);
        return updatedUser;
    }

    public async Task deleteById(int deleteId)
    {
        HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7093/Users/delete/{deleteId}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }
}