﻿using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IHangThietBiRepository : IRepository<HangThietBi>
    {

    }
    public class HangThietBiRepository : Repository<HangThietBi>, IHangThietBiRepository
    {
        public HangThietBiRepository(MyDbContext _db) : base(_db)
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
