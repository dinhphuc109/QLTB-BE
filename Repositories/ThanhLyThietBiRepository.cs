﻿using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{


    public interface IThanhLyThietBiRepository : IRepository<ThanhLyThietBi>
    {

    }
    public class ThanhLyThietBiRepository : Repository<ThanhLyThietBi>, IThanhLyThietBiRepository
    {
        public ThanhLyThietBiRepository(MyDbContext _db) : base(_db)
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
