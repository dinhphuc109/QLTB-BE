using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface INguoiNhanDieuChuyenRepository : IRepository<NguoiNhanDieuChuyen>
    {

    }
    public class NguoiNhanDieuChuyenRepository : Repository<NguoiNhanDieuChuyen>, INguoiNhanDieuChuyenRepository
    {
        public NguoiNhanDieuChuyenRepository(MyDbContext _db) : base(_db)
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
