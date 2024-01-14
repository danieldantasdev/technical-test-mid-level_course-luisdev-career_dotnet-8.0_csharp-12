using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Profile(uint idUser, ProfileUserEnum name, uint idStatus)
{
    [Column("id_user")]
    public uint IdUser { get; private set; } = idUser;
    [Column("name")]
    public ProfileUserEnum Name { get; private set; } = name;
    [Column("id_status")]
    public uint IdStatus { get; private set; } = idStatus;
}
