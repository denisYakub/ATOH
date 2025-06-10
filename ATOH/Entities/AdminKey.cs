using System.ComponentModel.DataAnnotations.Schema;

namespace ATOH.Entities
{
    [Table("admin_keys")]
    public class AdminKey
    {
        [ForeignKey("users")]
        Guid guid;
        Guid key;
    }
}
