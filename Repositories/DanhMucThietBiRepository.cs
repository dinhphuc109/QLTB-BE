using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface IDanhMucThietBiRepository : IRepository<DanhMucThietBi>
    {

    }
    public class DanhMucThietBiRepository : Repository<DanhMucThietBi>, IDanhMucThietBiRepository
    {
        public DanhMucThietBiRepository(MyDbContext _db) : base(_db)
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
