using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface ILoaiThietBiRepository : IRepository<LoaiThietBi>
    {

    }
    public class LoaiThietBiRepository : Repository<LoaiThietBi>, ILoaiThietBiRepository
    {
        public LoaiThietBiRepository(MyDbContext _db) : base(_db)
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
