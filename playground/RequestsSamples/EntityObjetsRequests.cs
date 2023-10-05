using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using playground.Entities;

namespace playground.RequestsSamples;
internal static class EntityObjectsRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client, Guid organizationId)
    {
        var entityRequestDto = new ProjectEntityObjectRequestDto
        {
            OrganizationId = organizationId,
            Name = "test1",
            Status = 10
        };

        var createdEntityObject = await client.EntityObjects.CreateAsync<ProjectEntityObjectRequestDto, ProjectEntityObjectResponseDto>(ProjectEntity.EntityName, entityRequestDto);
        Console.WriteLine($"Created entityObject name: {createdEntityObject!.Name}");

        var entityObjects = await client.EntityObjects.ListAsync<ProjectEntityObjectResponseDto>(ProjectEntity.EntityName, new ListQuery(50, 1, "name asc", null, "name, id, status", ""));
        Console.WriteLine($"Fetched entityObjects count: {entityObjects.Count}");

        var entityObject = await client.EntityObjects.GetByIdAsync<ProjectEntityObjectResponseDto>(ProjectEntity.EntityName, entityObjects[0].Id);
        Console.WriteLine($"Fetched entityObject name: {entityObject!.Name}");

        entityRequestDto.Id = createdEntityObject.Id;
        entityRequestDto.Name = "test1_updated";
        var updatedEntityObject = await client.EntityObjects.PatchAsync<ProjectEntityObjectRequestDto, ProjectEntityObjectResponseDto>(ProjectEntity.EntityName, createdEntityObject.Id, entityRequestDto);
        Console.WriteLine($"Updated entityObject name: {updatedEntityObject!.Name}");

        entityRequestDto.Name = "test1_updated_imported";
        var importEntityRequestDto = new ProjectEntityObjectRequestDto
        {
            OrganizationId = organizationId,
            Name = "test2",
            Status = 20
        };
        var importedEntityObjectIds = await client.EntityObjects.ImportAsync(ProjectEntity.EntityName, new List<ProjectEntityObjectRequestDto> { entityRequestDto, importEntityRequestDto });
        Console.WriteLine($"Imported entityObjects: {string.Join(",", importedEntityObjectIds)}");

        foreach (var importedId in importedEntityObjectIds)
        {
            await client.EntityObjects.DeleteAsync(ProjectEntity.EntityName, importedId);
            Console.WriteLine($"Deleted entityObject with id: {importedId}");
        }
    }
}
