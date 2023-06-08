using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface IBanGiaoTBRepository : IRepository<BanGiaoTB>
    {

    }
    public class BanGiaoTBRepository : Repository<BanGiaoTB>, IBanGiaoTBRepository
    {
        public BanGiaoTBRepository(MyDbContext _db) : base(_db)
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
