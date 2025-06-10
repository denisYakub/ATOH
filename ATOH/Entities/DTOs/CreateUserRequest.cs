namespace ATOH.Entities.DTOs
{
    public record struct CreateUserRequest(
        string Login,
        string Password,
        string Name,
        int Gender,
        DateTime? Birthday,
        bool Admin);
}
