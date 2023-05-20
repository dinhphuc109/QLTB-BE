using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IChucVuRepository : IRepository<ChucVu>
    {

    }
    public class ChucVuRepository : Repository<ChucVu>, IChucVuRepository
    {
        public ChucVuRepository(MyDbContext _db) : base(_db)
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
