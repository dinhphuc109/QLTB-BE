using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IKhoLoaiThietBiRepository : IRepository<KhoLoaiThietBi>
    {

    }
    public class KhoLoaiThietBiRepository : Repository<KhoLoaiThietBi>, IKhoLoaiThietBiRepository
    {
        public KhoLoaiThietBiRepository(MyDbContext _db) : base(_db)
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
