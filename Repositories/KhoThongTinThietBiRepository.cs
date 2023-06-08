using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IKhoThongTinThietBiRepository : IRepository<Kho_ThongTinThietBi>
    {

    }
    public class KhoThongTinThietBiRepository : Repository<Kho_ThongTinThietBi>, IKhoThongTinThietBiRepository
    {
        public KhoThongTinThietBiRepository(MyDbContext _db) : base(_db)
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
