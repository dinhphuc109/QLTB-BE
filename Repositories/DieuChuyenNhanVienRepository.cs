using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IDieuChuyenNhanVienRepository : IRepository<DieuChuyenNhanVien>
    {

    }
    public class DieuChuyenNhanVienRepository : Repository<DieuChuyenNhanVien>, IDieuChuyenNhanVienRepository
    {
        public DieuChuyenNhanVienRepository(MyDbContext _db) : base(_db)
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
