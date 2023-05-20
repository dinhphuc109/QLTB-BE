using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IHeThongRepository : IRepository<HeThong>
    {

    }
    public class HeThongRepository : Repository<HeThong>, IHeThongRepository
    {
        public HeThongRepository(MyDbContext _db) : base(_db)
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
