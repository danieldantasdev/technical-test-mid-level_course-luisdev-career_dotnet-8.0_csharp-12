using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Profile
{
    [Column("id_user")]
    public int IdUser { get; private set; }
    [Column("name")]
    public ProfileUserEnum Name { get; private set; }
    [Column("id_status")]
    public int IdStatus { get; private set; }

    public Profile()
    {
        IdUser = 0;
        Name = ProfileUserEnum.Candidate;
        IdStatus = 0;
    }

    public Profile(int idUser, ProfileUserEnum name, int idStatus)
    {
        IdUser = idUser;
        Name = name;
        IdStatus = idStatus;
    }

    public static Profile Create(int idUser, ProfileUserEnum name, int idStatus)
    {
        return new Profile
        {
            IdUser = idUser,
            Name = name,
            IdStatus = idStatus
        };
    }

    public static Profile Update(int idUser, ProfileUserEnum name, int idStatus)
    {
        return new Profile
        {
            IdUser = idUser,
            Name = name,
            IdStatus = idStatus
        };
    }
}
