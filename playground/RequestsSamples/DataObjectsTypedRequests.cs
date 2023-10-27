using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using playground.Entities;

namespace playground.RequestsSamples;

/// <summary>
/// Example of using resource DataObjects with typed data objects
/// </summary>
internal static class DataObjectsTypedRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var dataRequestDto = new SafetyCrossConcreteDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow,
            Status = 10
        };

        Console.WriteLine($"Create dataObject...");
        var createdDataObject = await client.DataObjects.CreateAsync<SafetyCrossConcreteDataObjectRequestDto, SafetyCrossConcreteDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, dataRequestDto);
        Console.WriteLine($"Created dataObject status: {createdDataObject!.Status}");

        Console.WriteLine($"Fetch dataObjects...");
        var dataObjects = await client.DataObjects.ListAsync<SafetyCrossConcreteDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, new ListQuery(50, 1, "comment asc", null, "comment, id, status", ""));
        Console.WriteLine($"Fetched dataObjects count: {dataObjects.Count}");

        Console.WriteLine($"Fetch dataObject by id...");
        var dataObject = await client.DataObjects.GetByIdAsync<SafetyCrossConcreteDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, dataObjects[0].Id!.Value);
        Console.WriteLine($"Fetched dataObject status: {dataObject!.Status}");

        Console.WriteLine($"Update dataObject...");
        dataRequestDto.Status = 20;
        var updatedDataObject = await client.DataObjects.PatchAsync<SafetyCrossConcreteDataObjectRequestDto, SafetyCrossConcreteDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, createdDataObject.Id!.Value, dataRequestDto);
        Console.WriteLine($"Updated dataObject status: {updatedDataObject!.Status}");

        Console.WriteLine($"Import dataObjects...");
        dataRequestDto.Status = 30;
        var importDataRequestDto = new SafetyCrossConcreteDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow.AddYears(-1),
            Status = 10
        };
        var importedDataObjectIds = await client.DataObjects.ImportAsync(SafetyCrossDataSource.DataSourceName, new List<SafetyCrossConcreteDataObjectRequestDto> { dataRequestDto, importDataRequestDto });
        Console.WriteLine($"Imported dataObjects: {string.Join(",", importedDataObjectIds)}");

        foreach (var importedId in importedDataObjectIds)
        {
            Console.WriteLine($"Delete dataObject...");
            await client.DataObjects.DeleteAsync(SafetyCrossDataSource.DataSourceName, importedId);
            Console.WriteLine($"Deleted dataObject with id: {importedId}");
        }
    }
}
