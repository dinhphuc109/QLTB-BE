using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface IDanhMucLoiRepository : IRepository<DanhMucLoi>
    {

    }
    public class DanhMucLoiRepository : Repository<DanhMucLoi>, IDanhMucLoiRepository
    {
        public DanhMucLoiRepository(MyDbContext _db) : base(_db)
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
