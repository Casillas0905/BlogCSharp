using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;
    public int id { get; set; }

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
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Posts/FindByParameters/{searchParameters}");
        string result = await response.Content.ReadAsStringAsync();
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

    public async Task<Post?> GetByIdAsync(int Id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Posts/findById/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post posts = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
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

    /*public async Task<IEnumerable<Post>> GetPosts(string? titleContains = null)
    {
        string uri = "/posts";
        if (!string.IsNullOrEmpty(titleContains))
        {
            uri += $"?title={titleContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
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

    public async Task<PostBasicDto> GetPostByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        PostBasicDto posts = JsonSerializer.Deserialize<PostBasicDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }*/


    
}