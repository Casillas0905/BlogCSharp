using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task CreateAsync(Post dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Posts/create",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<Post>> FindByParameters(SearchParameters searchParameters)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/posts/FindByParameters?title={searchParameters.title}&location={searchParameters.location}&category={searchParameters.category}&userId={searchParameters.userId}");
        string result = await response.Content.ReadAsStringAsync();
        bool status = response.IsSuccessStatusCode;
        Console.WriteLine(status);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> GetByIdAsync(int getById)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/posts/{getById}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Post posts = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine("post");
        return posts;
    }

    public async Task<IEnumerable<Post>> GetByUserIdAsync(int UserId)
    {
        Console.WriteLine("Http1");
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Posts/GetByUserIdAsync/{UserId}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Console.WriteLine("Http2");
        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine("Http3");
        return posts;
    }

    public async Task<Post?> Update(Post post)
    {
        Console.WriteLine("UpdateUser method called");
        HttpResponseMessage response = await client.PatchAsync("https://localhost:7093/posts/patch", new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json"));
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Post updatedPost = JsonSerializer.Deserialize<Post>(result);
        return updatedPost;
    }
}