using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface ITinhTrangThietBiRepository : IRepository<TinhTrangThietBi>
    {

    }
    public class TinhTrangThietBiRepository : Repository<TinhTrangThietBi>, ITinhTrangThietBiRepository
    {
        public TinhTrangThietBiRepository(MyDbContext _db) : base(_db)
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
