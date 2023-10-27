using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using playground.Entities;

namespace playground.RequestsSamples;
internal static class EntityObjectsTypedRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var entityRequestDto = new ProjectEntityObjectRequestDto
        {
            OrganizationId = organizationId,
            Name = "test1",
            Status = 10
        };

        Console.WriteLine($"Created entityObject...");
        var createdEntityObject = await client.EntityObjects.CreateAsync<ProjectEntityObjectRequestDto, ProjectEntityObjectResponseDto>(ProjectEntityTyped.EntityName, entityRequestDto);
        Console.WriteLine($"Created entityObject name: {createdEntityObject!.Name}");

        Console.WriteLine($"Fetch entityObjects...");
        var entityObjects = await client.EntityObjects.ListAsync<ProjectEntityObjectResponseDto>(ProjectEntityTyped.EntityName, new ListQuery(50, 1, "name asc", null, "name, id, status", ""));
        Console.WriteLine($"Fetched entityObjects count: {entityObjects.Count}");

        Console.WriteLine($"Fetch entityObject by id...");
        var entityObject = await client.EntityObjects.GetByIdAsync<ProjectEntityObjectResponseDto>(ProjectEntityTyped.EntityName, entityObjects[0].Id!.Value);
        Console.WriteLine($"Fetched entityObject name: {entityObject!.Name}");

        Console.WriteLine($"Update entityObject...");
        entityRequestDto.Id = createdEntityObject.Id;
        entityRequestDto.Name = "test1_updated";
        var updatedEntityObject = await client.EntityObjects.PatchAsync<ProjectEntityObjectRequestDto, ProjectEntityObjectResponseDto>(ProjectEntityTyped.EntityName, createdEntityObject.Id!.Value, entityRequestDto);
        Console.WriteLine($"Updated entityObject name: {updatedEntityObject!.Name}");

        Console.WriteLine($"Import entityObjects...");
        entityRequestDto.Name = "test1_updated_imported";
        var importEntityRequestDto = new ProjectEntityObjectRequestDto
        {
            OrganizationId = organizationId,
            Name = "test2",
            Status = 20
        };
        var importRequestDto = new ProjectEntityObjectImportRequestDto
        {
            DeleteOthers = false,
            EntityObjects = new List<ProjectEntityObjectRequestDto> { entityRequestDto, importEntityRequestDto }
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
