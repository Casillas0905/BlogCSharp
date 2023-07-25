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

    /*public async Task<Post?> GetByIdAsync(int Id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Posts/{id}");
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
    }*/
    
    /*public async Task<Post> GetByIdAsync(int postId)
    {
        try
        {
            string apiUrl = $"https://localhost:7093/findById?id={postId}";
            
            // Send the GET request
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            
            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();
                
                // Deserialize the response JSON to a Post object (assuming the JSON structure matches the Post class)
                // Replace "Post" with the class that matches your Post model
                Post post = await response.Content.ReadFromJsonAsync<Post>();
                
                return post;
            }
            else
            {
                // Handle the error as needed
                throw new Exception($"Failed to get the post. Status code: {response.StatusCode}");
            }
        }
        catch (Exception e)
        {
            // Handle the error as needed
            throw new Exception("An error occurred while fetching the post.", e);
        }
    }*/
    
    public async Task<Post> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
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
    }*/
    
}