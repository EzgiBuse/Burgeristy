using Burgeristy.DataAccessLayer.Abstract;
using Burgeristy.DataAccessLayer.Concrete;
using Burgeristy.DataAccessLayer.Repositories;
using Burgeristy.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgeristy.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(AppDbContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new AppDbContext();
            var values = context.Products.Include(x=>x.Category).ToList();
            return values;
        }
    }
}
