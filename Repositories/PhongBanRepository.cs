using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IPhongbanRepository : IRepository<Phongban>
    {

    }
    public class PhongbanRepository : Repository<Phongban>, IPhongbanRepository
    {
        public PhongbanRepository(MyDbContext _db) : base(_db)
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
