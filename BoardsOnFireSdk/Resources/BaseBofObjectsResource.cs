using BoardsOnFireSdk.Serialization;
using System.Net.Http.Json;

namespace BoardsOnFireSdk.Resources;
public abstract class BaseBofObjectsResource
{
    protected HttpClient HttpClient { get; }
    
    protected BaseBofObjectsResource(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    protected async Task<TResponseDto?> GetByIdAsync<TResponseDto>(string endpoint, Guid id)
    {
        using var response = await HttpClient.GetAsync($"{endpoint}/{id}");

        return await BoardsOnFireApiResponseHandler.Handle<TResponseDto>(response);
    }

    protected async Task<List<TResponseDto>> ListAsync<TResponseDto>(string endpoint, ListQuery query)
    {
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}/list", query, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<List<TResponseDto>>(response) ?? new List<TResponseDto>();
    }

    protected async Task<TResponseDto?> CreateAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto requestDto)
    {
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}", requestDto, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<TResponseDto>(response);
    }

    protected async Task<TResponseDto?> PatchAsync<TRequestDto, TResponseDto>(string endpoint, Guid id, TRequestDto requestDto)
    {
        using var response = await HttpClient.PatchAsJsonAsync($"{endpoint}/{id}", requestDto, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<TResponseDto>(response);
    }

    /// <summary>
    /// Upsert with import method
    /// </summary>
    /// <returns>Created + Updated ids</returns>
    protected async Task<List<Guid>> ImportAsync<TRequestDto>(string endpoint, List<TRequestDto> requestDtos)
    {
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}/import", requestDtos, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<List<Guid>>(response) ?? new List<Guid>();
    }

    protected async Task DeleteAsync(string endpoint, Guid id)
    {
        using var response = await HttpClient.DeleteAsync($"{endpoint}/{id}");

        await BoardsOnFireApiResponseHandler.Handle(response);
    }
}