﻿using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Models;

namespace NETCORE3.Repositories
{
    public interface IDanhMucKhoRepository : IRepository<DanhMucKho>
    {

    }
    public class DanhMucKhoRepository : Repository<DanhMucKho>, IDanhMucKhoRepository
    {
        public DanhMucKhoRepository(MyDbContext _db) : base(_db)
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
