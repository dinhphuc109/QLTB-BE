using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IBanGiaoNguoiNhanRepository : IRepository<BanGiao_NguoiNhan>
    {

    }
    public class BanGiaoNguoiNhanRepository : Repository<BanGiao_NguoiNhan>, IBanGiaoNguoiNhanRepository
    {
        public BanGiaoNguoiNhanRepository(MyDbContext _db) : base(_db)
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
