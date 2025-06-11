using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ATOH.Entities.Enums;
using ATOH.Entities.Exceptions;
using ATOH.Interfaces;

namespace ATOH.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Guid { get; private set; }

        [Column("login")]
        public string Login { get; private set; }
        [Column("password")]
        public string Password { get; private set; }
        [Column("name")]
        public string Name { get; private set; }
        [Column("gender")]
        public int Gender { get; private set; }
        [Column("birthday")]
        public DateTime? Birthday { get; private set; }
        [Column("admin")]
        public bool Admin { get; private set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; private set; }
        [Column("created_by")]
        public string CreatedBy { get; private set; }
        [Column("modified_on")]
        public DateTime? ModifiedOn { get; private set; }
        [Column("modified_by")]
        public string? ModifiedBy { get; private set; }
        [Column("revoked_on")]
        public DateTime? RevokedOn { get; private set; }
        [Column("revoked_by")]
        public string? RevokedBy { get; private set; }

        public User(
            string login, string password, 
            string name, int gender, 
            DateTime? birthday, 
            bool admin,
            string createBy)
        {
            Guid = Guid.NewGuid();

            Login = login;
            Password = password;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Admin = admin;

            CreatedBy = createBy;
            CreatedOn = DateTime.UtcNow;
        }

        public User(
            Guid guid, string login, string password,
            string name, int gender,
            DateTime? birthday,
            bool admin,
            DateTime createdOn, string createBy,
            DateTime? modifiedOn, string? modifiedBy,
            DateTime? revokedOn, string? revokedBy)
        {
            Guid = guid;
            Login = login;
            Password = password;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            Admin = admin;
            CreatedOn = createdOn;
            CreatedBy = createBy;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
            RevokedOn = revokedOn;
            RevokedBy = revokedBy;
        }

        private User() { }

        public void UpdateField(FieldsToUpdate field, string newValue)
        {
            if (!CanUpdateField())
                throw new BadRequestException($"User {field} can not be updated");

            try
            {
                switch (field)
                {
                    case Entities.Enums.FieldsToUpdate.Name:
                        Name = newValue;
                        break;
                    case Entities.Enums.FieldsToUpdate.Gender:
                        Gender = int.Parse(newValue);
                        break;
                    case Entities.Enums.FieldsToUpdate.Birthday:
                        Birthday = DateTime.Parse(newValue);
                        break;
                    case Entities.Enums.FieldsToUpdate.Password:
                        Password = newValue;
                        break;
                    case Entities.Enums.FieldsToUpdate.Login:
                        Login = newValue;
                        break;
                    default:
                        throw new BadRequestException($"Not allowed to update {field} field");
                }
            }
            catch (FormatException ex)
            {
                throw new BadRequestException($"New value is a wrong type: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                throw new BadRequestException($"New value is a wrong type: {ex.Message}");
            }
        }

        public void SoftDelete(string admin)
        {
            RevokedBy = admin;
            RevokedOn = DateTime.UtcNow;
        }

        private bool CanUpdateField()
        {
            if (Admin || (RevokedBy == null && RevokedOn == null))
                return true;
            else
                return false;
        }
    }
}
