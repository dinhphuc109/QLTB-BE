using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface INguoiNhanDieuChuyenRepository : IRepository<NguoiNhan_DieuChuyen>
    {

    }
    public class NguoiNhanDieuChuyenRepository : Repository<NguoiNhan_DieuChuyen>, INguoiNhanDieuChuyenRepository
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
