using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using playground.Entities;

namespace playground.RequestsSamples;
internal static class DataObjectsRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var dataRequestDto = new SafetyCrossDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow,
            Status = 10
        };
        var createdDataObject = await client.DataObjects.CreateAsync<SafetyCrossDataObjectRequestDto, SafetyCrossDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, dataRequestDto);
        Console.WriteLine($"Created dataObject status: {createdDataObject!.Status}");

        var dataObjects = await client.DataObjects.ListAsync<SafetyCrossDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, new ListQuery(50, 1, "comment asc", null, "comment, id, status", ""));
        Console.WriteLine($"Fetched dataObjects count: {dataObjects.Count}");

        var dataObject = await client.DataObjects.GetByIdAsync<SafetyCrossDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, dataObjects[0].Id);
        Console.WriteLine($"Fetched dataObject status: {dataObject!.Status}");

        dataRequestDto.Status = 20;
        var updatedDataObject = await client.DataObjects.PatchAsync<SafetyCrossDataObjectRequestDto, SafetyCrossDataObjectResponseDto>(SafetyCrossDataSource.DataSourceName, createdDataObject.Id, dataRequestDto);
        Console.WriteLine($"Updated dataObject status: {updatedDataObject!.Status}");

        dataRequestDto.Status = 30;
        var importDataRequestDto = new SafetyCrossDataObjectRequestDto
        {
            OrganizationId = organizationId,
            Timestamp = DateTime.UtcNow.AddYears(-1),
            Status = 10
        };
        var importedDataObjectIds = await client.DataObjects.ImportAsync(SafetyCrossDataSource.DataSourceName, new List<SafetyCrossDataObjectRequestDto> { dataRequestDto, importDataRequestDto });
        Console.WriteLine($"Imported dataObjects: {string.Join(",", importedDataObjectIds)}");

        foreach (var importedId in importedDataObjectIds)
        {
            await client.DataObjects.DeleteAsync(SafetyCrossDataSource.DataSourceName, importedId);
            Console.WriteLine($"Deleted dataObject with id: {importedId}");
        }
    }
}
