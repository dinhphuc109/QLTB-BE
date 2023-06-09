using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface ICBNV_DieuChuyenRepository : IRepository<CBNV_DieuChuyen>
    {

    }
    public class CBNV_DieuChuyenRepository : Repository<CBNV_DieuChuyen>, ICBNV_DieuChuyenRepository
    {
        public CBNV_DieuChuyenRepository(MyDbContext _db) : base(_db)
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
