﻿using BoardsOnFireSdk.Extensions;

namespace BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;

/// <summary>
/// Dynamic response dto includes default properties
/// and you add your custom data source properties dynamically to DataProperties
/// </summary>
public class DynamicEntityObjectResponseDto : IEntityObjectResponseDto
{
    public DynamicEntityObjectResponseDto(Dictionary<string, object?> responseDictionary)
    {
        Id = responseDictionary.ParseGuid(nameof(Id));
        CreatedAt = responseDictionary.ParseDateTime(nameof(CreatedAt));
        UpdatedAt = responseDictionary.ParseDateTime(nameof(UpdatedAt));
        ArchivedAt = responseDictionary.ParseDateTime(nameof(ArchivedAt));
        ExternalId = responseDictionary.ParseString(nameof(ExternalId));

        DataProperties = responseDictionary;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? ExternalId { get; set; }
    public Dictionary<string, object?> DataProperties { get; set; }
}
