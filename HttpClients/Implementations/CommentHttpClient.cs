using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CommentHttpClient : ICommentService
{
    private readonly HttpClient client;

    public CommentHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(Comment dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Comment",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
    public async Task<IEnumerable<Comment>> GetByPostIdAsync(int PostId)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Comment/{PostId}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Comment> comments = JsonSerializer.Deserialize<IEnumerable<Comment>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comments;
    }
}