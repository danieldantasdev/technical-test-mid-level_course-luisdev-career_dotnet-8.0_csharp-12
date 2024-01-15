using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class User : BaseEntity
{
    [Column("name")]
    public string Name { get; private set; }
    [Column("email")]
    public string Email { get; private set; }
    [Column("password")]
    public string Password { get; private set; }
    [Column("id_status")]
    public int IdStatus { get; private set; }

    public User()
    {
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        IdStatus = 0;
    }

    public User(string name, string email, string password, int idStatus)
    {
        Name = name;
        Email = email;
        Password = password;
        IdStatus = idStatus;
    }

    public static User Create(string name, string email, string password, int idStatus)
    {
        return new User
        {
            Name = name,
            Email = email,
            Password = password,
            IdStatus = idStatus
        };
    }

    public static User Update(string name, string email, string password, int idStatus)
    {
        return new User
        {
            Name = name,
            Email = email,
            Password = password,
            IdStatus = idStatus
        };
    }
}
