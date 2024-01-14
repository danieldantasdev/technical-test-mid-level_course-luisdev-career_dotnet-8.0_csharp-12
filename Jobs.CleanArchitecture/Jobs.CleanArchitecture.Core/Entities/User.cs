using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class User(string name, string email, string password, uint idStatus) : BaseEntity
{
    [Column("name")]
    public string Name { get; private set; } = name;
    [Column("email")]
    public string Email { get; private set; } = email;
    [Column("password")]
    public string Password { get; private set; } = password;
    [Column("id_status")]
    public uint IdStatus { get; private set; } = idStatus;
}
