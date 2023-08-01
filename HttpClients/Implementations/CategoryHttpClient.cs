using System.Net.Http.Json;
using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CategoryHttpClient : ICategoryService
{
    private readonly HttpClient client;

    public CategoryHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task saveCategory(Category Category)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/category/create",Category);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<Category>> findAll()
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/category/GetAll");
        string result = await response.Content.ReadAsStringAsync();
        bool status = response.IsSuccessStatusCode;
        Console.WriteLine(status);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Category> categories = JsonSerializer.Deserialize<IEnumerable<Category>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return categories;
    }

    public async Task<Category> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/category/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Category category = JsonSerializer.Deserialize<Category>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine("category");
        return category;
    }
}