using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface ITieuChuanBaoTriRepository : IRepository<TieuChuanBaoTri>
    {

    }
    public class TieuChuanBaoTriRepository : Repository<TieuChuanBaoTri>, ITieuChuanBaoTriRepository
    {
        public TieuChuanBaoTriRepository(MyDbContext _db) : base(_db)
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
