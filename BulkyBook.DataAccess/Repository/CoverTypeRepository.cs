﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    internal class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDBContext _db;
        public CoverTypeRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType obj)
        {
            _db.coverTypes.Update(obj);
        }
    }
}
