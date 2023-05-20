using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IDonViTraLuongRepository : IRepository<DonViTraLuong>
    {

    }
    public class DonViTraLuongRepository : Repository<DonViTraLuong>, IDonViTraLuongRepository
    {
        public DonViTraLuongRepository(MyDbContext _db) : base(_db)
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
