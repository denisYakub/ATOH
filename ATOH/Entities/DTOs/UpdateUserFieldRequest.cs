namespace ATOH.Entities.DTOs
{
    public record struct UpdateUserFieldRequest(
        string Field,
        string NewValue);
}
