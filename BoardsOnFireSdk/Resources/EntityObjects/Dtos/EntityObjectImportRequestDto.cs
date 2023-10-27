namespace BoardsOnFireSdk.Resources.EntityObjects.Dtos;
public class EntityObjectImportRequestDto<T>
{
    public bool DeleteOthers { get; set; }
    public required List<T> EntityObjects { get; set; }
}