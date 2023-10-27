using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using BoardsOnFireSdk.Resources.EntityObjects.Dtos;
using BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;
using playground.Entities;

namespace playground.RequestsSamples;

/// <summary>
/// Example of using resource EntityObjects with dynamic entity objects
/// </summary>
internal static class EntityObjectsDynamicRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var entityRequestDto = new DynamicEntityObjectRequestDto
        {
            OrganizationId = organizationId
        };
        entityRequestDto.DataProperties.Add("name", "test1");
        entityRequestDto.DataProperties.Add("status", 10);

        Console.WriteLine($"Create entity object...");
        var createdEntityObject = await client.EntityObjects.CreateAsync(ProjectEntityTyped.EntityName, entityRequestDto);
        Console.WriteLine($"Created entityObject name: {createdEntityObject!.DataProperties["name"]}");

        Console.WriteLine($"Fetch entityObjects...");
        var entityObjects = await client.EntityObjects.ListAsync(ProjectEntityTyped.EntityName, new ListQuery(50, 1, "name asc", null, "name, id, status", ""));
        Console.WriteLine($"Fetched entityObjects count: {entityObjects.Count}");

        Console.WriteLine($"Fetch entityObject by id...");
        var entityObject = await client.EntityObjects.GetByIdAsync(ProjectEntityTyped.EntityName, entityObjects[0].Id!.Value);
        Console.WriteLine($"Fetched entityObject name: {entityObject!.DataProperties["name"]}");

        Console.WriteLine($"Update entityObject...");
        entityRequestDto.Id = createdEntityObject.Id;
        entityRequestDto.DataProperties["name"] = "test1_updated";
        var updatedEntityObject = await client.EntityObjects.PatchAsync(ProjectEntityTyped.EntityName, createdEntityObject.Id!.Value, entityRequestDto);
        Console.WriteLine($"Updated entityObject name: {updatedEntityObject!.DataProperties["name"]}");

        Console.WriteLine($"Import entityObjects...");
        entityRequestDto.DataProperties["name"] = "test1_updated_imported";
        var importEntityRequestDto = new DynamicEntityObjectRequestDto
        {
            OrganizationId = organizationId
        };
        importEntityRequestDto.DataProperties.Add("name", "test2");
        importEntityRequestDto.DataProperties.Add("status", 20);

        var importRequestDto = new EntityObjectImportRequestDto<DynamicEntityObjectRequestDto>
        {
            DeleteOthers = false,
            EntityObjects = new List<DynamicEntityObjectRequestDto> { entityRequestDto, importEntityRequestDto }
        };

        var importedEntityObjectIds = await client.EntityObjects.ImportAsync(ProjectEntityTyped.EntityName, importRequestDto);
        Console.WriteLine($"Imported entityObjects: {string.Join(",", importedEntityObjectIds)}");

        foreach (var importedId in importedEntityObjectIds)
        {
            Console.WriteLine($"Delete entityObject...");
            await client.EntityObjects.DeleteAsync(ProjectEntityTyped.EntityName, importedId);
            Console.WriteLine($"Deleted entityObject with id: {importedId}");
        }
    }
}
