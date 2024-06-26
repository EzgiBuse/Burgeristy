﻿using Burgeristy.DataAccessLayer.Abstract;
using Burgeristy.DataAccessLayer.Concrete;
using Burgeristy.DataAccessLayer.Repositories;
using Burgeristy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgeristy.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(AppDbContext context) : base(context)
        {
        }

    }
}
