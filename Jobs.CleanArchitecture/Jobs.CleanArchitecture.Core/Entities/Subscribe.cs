using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Subscribe : BaseEntity
{
    [Column("id_user")]
    public int IdUser { get; private set; }
    [Column("id_job")]
    public int IdJob { get; private set; }
    [Column("date")]
    public DateTime Date { get; private set; }

    public Subscribe()
    {
        IdUser = 0;
        IdJob = 0;
        Date = DateTime.Now;
    }

    public Subscribe(int idUser, int idjob, DateTime date)
    {
        IdUser = idUser;
        IdJob = idjob;
        Date = date;
    }

    public static Subscribe Create(int idUser, int idjob, DateTime date)
    {
        return new Subscribe
        {
            IdUser = idUser,
            IdJob = idjob,
            Date = date
        };
    }

    public static Subscribe Update(int idUser, int idjob, DateTime date)
    {
        return new Subscribe
        {
            IdUser = idUser,
            IdJob = idjob,
            Date = date
        };
    }
}
