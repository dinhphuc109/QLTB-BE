using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface ILoaiHangThietBiRepository : IRepository<Loai_HangThietBi>
    {

    }
    public class LoaiHangThietBiRepository : Repository<Loai_HangThietBi>, ILoaiHangThietBiRepository
    {
        public LoaiHangThietBiRepository(MyDbContext _db) : base(_db)
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
