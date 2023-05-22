using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE3.Repositories
{
    public interface IThongTinHangThietBiRepository : IRepository<ThongTinHangThietBi>
    {

    }
    public class ThongTinHangThietBiRepository : Repository<ThongTinHangThietBi>, IThongTinHangThietBiRepository
    {
        public ThongTinHangThietBiRepository(MyDbContext _db) : base(_db)
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
