using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IChiTietLoaiThongTinThietBiRepository : IRepository<ChiTietLoaiThongTinThietBi>
    {

    }
    public class ChiTietLoaiThongTinThietBiRepository : Repository<ChiTietLoaiThongTinThietBi>, IChiTietLoaiThongTinThietBiRepository
    {
        public ChiTietLoaiThongTinThietBiRepository(MyDbContext _db) : base(_db)
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
