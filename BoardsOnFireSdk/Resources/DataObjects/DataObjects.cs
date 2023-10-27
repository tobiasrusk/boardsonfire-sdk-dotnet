using BoardsOnFireSdk.Exceptions;
using BoardsOnFireSdk.Resources.DataObjects.Dtos;
using BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;

namespace BoardsOnFireSdk.Resources.DataObjects;

/// <summary>
/// Resource for list, get, create, update, import and delete data objects
/// </summary>
public class DataObjects : BaseBofObjectsResource
{
    private static string Endpoint(string dataSourceName) => $"datasources/{dataSourceName}/dataobjects";

    public DataObjects(HttpClient httpClient) : base(httpClient)
    {
    }

    public new async Task<TResponseDto?> GetByIdAsync<TResponseDto>(string dataSourceName, Guid id) where TResponseDto : IDataObjectResponseDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.GetByIdAsync<TResponseDto>(endpoint, id);
    }

    public async Task<DynamicDataObjectResponseDto?> GetByIdAsync(string dataSourceName, Guid id)
    {
        var endpoint = Endpoint(dataSourceName);
        var responseDictionary = await base.GetByIdAsync<Dictionary<string, object?>>(endpoint, id);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicDataObjectResponseDto(responseDictionary);
    }

    public new async Task<List<TResponseDto>> ListAsync<TResponseDto>(string dataSourceName, ListQuery query) where TResponseDto : IDataObjectResponseDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.ListAsync<TResponseDto>(endpoint, query);
    }

    public async Task<List<DynamicDataObjectResponseDto>> ListAsync(string dataSourceName, ListQuery query)
    {
        var endpoint = Endpoint(dataSourceName);
        var responseDictionaries = await base.ListAsync<Dictionary<string, object?>>(endpoint, query);

        if (responseDictionaries == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        var responseDtos = new List<DynamicDataObjectResponseDto>();
        foreach (var dictionary in responseDictionaries)
        {
            responseDtos.Add(new DynamicDataObjectResponseDto(dictionary));
        }

        return responseDtos;
    }

    public new async Task<TResponseDto?> CreateAsync<TRequestDto, TResponseDto>(string dataSourceName, TRequestDto requestDto)
        where TResponseDto : IDataObjectResponseDto
        where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.CreateAsync<TRequestDto, TResponseDto>(endpoint, requestDto);
    }

    public async Task<DynamicDataObjectResponseDto?> CreateAsync(string dataSourceName, DynamicDataObjectRequestDto requestDto)
    {
        var requestDictionary = requestDto.ToDictionary();
        var endpoint = Endpoint(dataSourceName);
        var responseDictionary = await base.CreateAsync<Dictionary<string, object?>, Dictionary<string, object?>>(endpoint, requestDictionary);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicDataObjectResponseDto(responseDictionary);
    }

    public new async Task<TResponseDto?> PatchAsync<TRequestDto, TResponseDto>(string dataSourceName, Guid id, TRequestDto requestDto)
        where TResponseDto : IDataObjectResponseDto
        where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.PatchAsync<TRequestDto, TResponseDto>(endpoint, id, requestDto);
    }

    public async Task<DynamicDataObjectResponseDto?> PatchAsync(string dataSourceName, Guid id, DynamicDataObjectRequestDto requestDto)
    {
        var requestDictionary = requestDto.ToDictionary();
        var endpoint = Endpoint(dataSourceName);
        var responseDictionary = await base.PatchAsync<Dictionary<string, object?>, Dictionary<string, object?>>(endpoint, id, requestDictionary);

        if (responseDictionary == null)
        {
            throw new BoardsOnFireApiException("Response dictionary is null");
        }

        return new DynamicDataObjectResponseDto(responseDictionary);
    }

    public new async Task<List<Guid>> ImportAsync<TRequestDto>(string dataSourceName, List<TRequestDto> requestDtos) where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.ImportAsync(endpoint, requestDtos);
    }

    public async Task<List<Guid>> ImportAsync(string dataSourceName, List<DynamicDataObjectRequestDto> requestDtos)
    {
        var requestDictionaries = new List<Dictionary<string, object?>>();
        foreach (var requestDto in requestDtos)
        {
            requestDictionaries.Add(requestDto.ToDictionary());
        }

        var endpoint = Endpoint(dataSourceName);
        return await base.ImportAsync(endpoint, requestDictionaries);
    }

    public new async Task DeleteAsync(string dataSourceName, Guid id)
    {
        var endpoint = Endpoint(dataSourceName);
        await base.DeleteAsync(endpoint, id);
    }
}