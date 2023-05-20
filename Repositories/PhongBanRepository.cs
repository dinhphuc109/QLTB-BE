﻿using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IPhongBanRepository : IRepository<Phongban>
    {

    }
    public class PhongBanRepository : Repository<Phongban>, IPhongBanRepository
    {
        public PhongBanRepository(MyDbContext _db) : base(_db)
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
