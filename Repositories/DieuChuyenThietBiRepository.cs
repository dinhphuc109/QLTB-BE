using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface IDieuChuyenThietBiRepository : IRepository<DieuChuyenThietBi>
    {

    }
    public class DieuChuyenThietBiRepository : Repository<DieuChuyenThietBi>, IDieuChuyenThietBiRepository
    {
        public DieuChuyenThietBiRepository(MyDbContext _db) : base(_db)
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
