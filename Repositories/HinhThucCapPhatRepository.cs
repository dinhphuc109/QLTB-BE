using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{

    public interface IHinhThucCapPhatRepository : IRepository<HinhThucCapPhat>
    {

    }
    public class HinhThucCapPhatRepository : Repository<HinhThucCapPhat>, IHinhThucCapPhatRepository
    {
        public HinhThucCapPhatRepository(MyDbContext _db) : base(_db)
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
