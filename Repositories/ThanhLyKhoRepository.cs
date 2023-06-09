﻿using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IThanhLyKhoRepository : IRepository<ThanhLy_Kho>
    {

    }
    public class ThanhLyKhoRepository : Repository<ThanhLy_Kho>, IThanhLyKhoRepository
    {
        public ThanhLyKhoRepository(MyDbContext _db) : base(_db)
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
