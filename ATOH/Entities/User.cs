using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATOH.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        Guid guid;
        string login;
        string password;
        string name;
        int gender;
        DateTime? birthday;
        bool Admin;
        DateTime createdOn;
        string createdBy;
        DateTime modifiedOn;
        string modifiedBy;
        DateTime revokedOn;
        string revokedBy;
    }
}
