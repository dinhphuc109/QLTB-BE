using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface ILichSuThietBiRepository : IRepository<LichSuThietBi>
    {

    }
    public class LichSuThietBiRepository : Repository<LichSuThietBi>, ILichSuThietBiRepository
    {
        public LichSuThietBiRepository(MyDbContext _db) : base(_db)
        {
        }
        public MyDbContext MyDbContext
        {
            get
            {
                return _db as MyDbContext;
            }
        }


    }
}
