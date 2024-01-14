using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class Profile(uint idUser, ProfileUserEnum name, StatusUserEnum status)
{
    [Column("id_user")]
    public uint IdUser { get; private set; } = idUser;
    [Column("name")]
    public ProfileUserEnum Name { get; private set; } = name;
    [Column("status")]
    public StatusUserEnum Status { get; private set; } = status;
}
