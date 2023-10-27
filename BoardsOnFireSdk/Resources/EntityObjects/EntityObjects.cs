using BoardsOnFireSdk.Exceptions;
using BoardsOnFireSdk.Resources.EntityObjects.Dtos;
using BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;
using BoardsOnFireSdk.Serialization;
using System.Net.Http.Json;

namespace BoardsOnFireSdk.Resources.EntityObjects;

/// <summary>
/// Resource for list, get, create, update, import and delete entity objects
/// </summary>
public class EntityObjects : BaseBofObjectsResource
{
    private static string Endpoint(string entityName) => $"entities/{entityName}/entityobjects";

    public EntityObjects(HttpClient httpClient) : base(httpClient)
    {
    }

    public new async Task<TDynamicDto?> GetByIdAsync<TDynamicDto>(string entityName, Guid id) where TDynamicDto : IEntityObjectResponseDto
    {
        var endpoint = Endpoint(entityName);
        return await base.GetByIdAsync<TDynamicDto>(endpoint, id);
    }

    public async Task<DynamicEntityObjectResponseDto?> GetByIdAsync(string entityName, Guid id)
    {
        var endpoint = Endpoint(entityName);
        var responseDictionary = await base.GetByIdAsync<Dictionary<string, object?>>(endpoint, id);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicEntityObjectResponseDto(responseDictionary);
    }

    public new async Task<List<TDynamicDto>> ListAsync<TDynamicDto>(string entityName, ListQuery query) where TDynamicDto : IEntityObjectResponseDto
    {
        var endpoint = Endpoint(entityName);
        return await base.ListAsync<TDynamicDto>(endpoint, query);
    }

    public async Task<List<DynamicEntityObjectResponseDto>> ListAsync(string entityName, ListQuery query)
    {
        var endpoint = Endpoint(entityName);
        var responseDictionaries = await base.ListAsync<Dictionary<string, object?>>(endpoint, query);

        if (responseDictionaries == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        var responseDtos = new List<DynamicEntityObjectResponseDto>();
        foreach (var dictionary in responseDictionaries)
        {
            responseDtos.Add(new DynamicEntityObjectResponseDto(dictionary));
        }

        return responseDtos;
    }

    public new async Task<TResponseDto?> CreateAsync<TRequestDto, TResponseDto>(string entityName, TRequestDto requestDto) 
        where TResponseDto : IEntityObjectResponseDto 
        where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        return await base.CreateAsync<TRequestDto, TResponseDto>(endpoint, requestDto);
    }

    public async Task<DynamicEntityObjectResponseDto?> CreateAsync(string entityName, DynamicEntityObjectRequestDto requestDto)
    {
        var requestDictionary = requestDto.ToDictionary();
        var endpoint = Endpoint(entityName);
        var responseDictionary = await base.CreateAsync<Dictionary<string, object?>, Dictionary<string, object?>>(endpoint, requestDictionary);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicEntityObjectResponseDto(responseDictionary);
    }

    public new async Task<TResponseDto?> PatchAsync<TRequestDto, TResponseDto>(string entityName, Guid id, TRequestDto requestDto)
        where TResponseDto : IEntityObjectResponseDto
        where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        return await base.PatchAsync<TRequestDto, TResponseDto>(endpoint, id, requestDto);
    }

    public async Task<DynamicEntityObjectResponseDto?> PatchAsync(string entityName, Guid id, DynamicEntityObjectRequestDto requestDto)
    {
        var requestDictionary = requestDto.ToDictionary();
        var endpoint = Endpoint(entityName);
        var responseDictionary = await base.PatchAsync<Dictionary<string, object?>, Dictionary<string, object?>>(endpoint, id, requestDictionary);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicEntityObjectResponseDto(responseDictionary);
    }

    public async Task<List<Guid>> ImportAsync<TRequestDto>(string entityName, EntityObjectImportRequestDto<TRequestDto> importRequestDto) where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}/import", importRequestDto, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<List<Guid>>(response) ?? new List<Guid>();
    }

    public async Task<List<Guid>> ImportAsync(string entityName, EntityObjectImportRequestDto<DynamicEntityObjectRequestDto> importRequestDto)
    {
        var requestDictionaries = new List<Dictionary<string, object?>>();
        foreach (var requestDto in importRequestDto.EntityObjects)
        {
            requestDictionaries.Add(requestDto.ToDictionary());
        }

        var requestModel = new EntityObjectImportRequestDto<Dictionary<string, object?>>
        {
            DeleteOthers = importRequestDto.DeleteOthers,
            EntityObjects = requestDictionaries
        };

        var endpoint = Endpoint(entityName);
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}/import", requestModel, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<List<Guid>>(response) ?? new List<Guid>();
    }

    public new async Task DeleteAsync(string entityName, Guid id)
    {
        var endpoint = Endpoint(entityName);
        await base.DeleteAsync(endpoint, id);
    }
}