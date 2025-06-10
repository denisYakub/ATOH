using System.ComponentModel.DataAnnotations.Schema;

namespace ATOH.Entities
{
    [Table("user_keys")]
    public class UserKey
    {
        [ForeignKey("users")]
        Guid guid;
        Guid key;
    }
}
