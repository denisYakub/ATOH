using System.ComponentModel.DataAnnotations.Schema;

namespace ATOH.DataBase.Views
{
    [Table("view_admin_tokens")]
    public class AdminTokenView
    {
        [Column("id")]
        public Guid AdminGuid { get; private set; }
        [Column("token")]
        public Guid Token { get; private set; }
    }
}
