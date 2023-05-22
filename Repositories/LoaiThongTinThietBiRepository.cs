using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE3.Repositories
{
    public interface ILoaiThongTinThietBiRepository : IRepository<LoaiThongTinThietBi>
    {

    }
    public class LoaiThongTinThietBiRepository : Repository<LoaiThongTinThietBi>, ILoaiThongTinThietBiRepository
    {
        public LoaiThongTinThietBiRepository(MyDbContext _db) : base(_db)
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
