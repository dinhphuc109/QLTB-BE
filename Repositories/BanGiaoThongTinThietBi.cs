using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IBanGiaoThongTinThietBiRepository : IRepository<BanGiao_ThongTinThietBi>
    {

    }
    public class BanGiaoThongTinThietBiRepository : Repository<BanGiao_ThongTinThietBi>, IBanGiaoThongTinThietBiRepository
    {
        public BanGiaoThongTinThietBiRepository(MyDbContext _db) : base(_db)
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
