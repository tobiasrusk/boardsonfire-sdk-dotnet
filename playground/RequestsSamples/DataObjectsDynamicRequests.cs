using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;
using playground.Entities;

namespace playground.RequestsSamples;

/// <summary>
/// Example of using resource DataObjects with dynamic data objects
/// </summary>
internal static class DataObjectsDynamicRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var dataRequestDto = new DynamicDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow.AddDays(8)
        };
        dataRequestDto.DataProperties.Add("status", 10);

        Console.WriteLine($"Create data object...");
        var createdDataObject = await client.DataObjects.CreateAsync(SafetyCrossDataSource.DataSourceName, dataRequestDto);
        Console.WriteLine($"Created dataObject status: {createdDataObject!.DataProperties["status"]}");

        Console.WriteLine($"Fetch dataObjects...");
        var dataObjects = await client.DataObjects.ListAsync(SafetyCrossDataSource.DataSourceName, new ListQuery(50, 1, "comment asc", null, "comment, id, status", ""));
        Console.WriteLine($"Fetched dataObjects count: {dataObjects.Count}");

        Console.WriteLine($"Fetch dataObject by id...");
        var dataObject = await client.DataObjects.GetByIdAsync(SafetyCrossDataSource.DataSourceName, dataObjects[0].Id!.Value);
        Console.WriteLine($"Fetched dataObject status: {dataObject!.DataProperties["status"]}");

        Console.WriteLine($"Update dataObject...");
        dataRequestDto.DataProperties["status"] = 20;
        var updatedDataObject = await client.DataObjects.PatchAsync(SafetyCrossDataSource.DataSourceName, createdDataObject.Id!.Value, dataRequestDto);
        Console.WriteLine($"Updated dataObject status: {updatedDataObject!.DataProperties["status"]}");

        Console.WriteLine($"Import dataObjects...");
        dataRequestDto.DataProperties["status"] = 30;
        var importDataRequestDto = new DynamicDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow.AddYears(-1),
        };
        importDataRequestDto.DataProperties.Add("status", 10);

        var importedDataObjectIds = await client.DataObjects.ImportAsync(SafetyCrossDataSource.DataSourceName, new List<DynamicDataObjectRequestDto> { dataRequestDto, importDataRequestDto });
        Console.WriteLine($"Imported dataObjects: {string.Join(",", importedDataObjectIds)}");

        foreach (var importedId in importedDataObjectIds)
        {
            Console.WriteLine($"Delete dataObject...");
            await client.DataObjects.DeleteAsync(SafetyCrossDataSource.DataSourceName, importedId);
            Console.WriteLine($"Deleted dataObject with id: {importedId}");
        }
    }
}
