using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATOH.Entities
{
    [Table("user_tokens")]
    public class UserToken
    {
        [Key]
        [Column("id")]
        public Guid Guid { get; private set; }
        [ForeignKey("users")]
        [Column("user_id")]
        public Guid UserGuid { get; set; }
        [Column("token")]
        public Guid Token { get; private set; }

        public UserToken(Guid userGuid)
        {
            Guid = Guid.NewGuid();
            UserGuid = userGuid;
            Token = Guid.NewGuid();
        }

        public UserToken() { }
    }
}
