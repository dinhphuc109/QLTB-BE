using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IDieuChuyenThietBiKhoRepository : IRepository<DieuChuyenThietBi_Kho>
    {

    }
    public class DieuChuyenThietBiKhoRepository : Repository<DieuChuyenThietBi_Kho>, IDieuChuyenThietBiKhoRepository
    {
        public DieuChuyenThietBiKhoRepository(MyDbContext _db) : base(_db)
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
