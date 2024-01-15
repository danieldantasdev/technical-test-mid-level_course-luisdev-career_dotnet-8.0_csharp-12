using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Profile(int idUser, ProfileUserEnum name, int idStatus)
{
    [Column("id_user")]
    public int IdUser { get; private set; } = idUser;
    [Column("name")]
    public ProfileUserEnum Name { get; private set; } = name;
    [Column("id_status")]
    public int IdStatus { get; private set; } = idStatus;
}
