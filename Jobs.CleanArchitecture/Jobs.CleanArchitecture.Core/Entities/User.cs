using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class User(string name, string email, string password, int idStatus) : BaseEntity
{
    [Column("name")]
    public string Name { get; private set; } = name;
    [Column("email")]
    public string Email { get; private set; } = email;
    [Column("password")]
    public string Password { get; private set; } = password;
    [Column("id_status")]
    public int IdStatus { get; private set; } = idStatus;
}
