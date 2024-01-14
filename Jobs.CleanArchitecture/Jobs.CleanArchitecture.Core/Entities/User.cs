using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class User(string name, string email, string password) : BaseEntity
{
    [Column("name")]
    public string Name { get; private set; } = name;
    [Column("email")]
    public string Email { get; private set; } = email;
    [Column("password")]
    public string Password { get; private set; } = password;
}
