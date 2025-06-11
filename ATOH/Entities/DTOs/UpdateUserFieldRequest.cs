using ATOH.Entities.Enums;

namespace ATOH.Entities.DTOs
{
    public record struct UpdateUserFieldRequest(
        FieldsToUpdate Field,
        string NewValue);
}
