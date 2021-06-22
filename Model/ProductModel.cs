using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductModel
    {
        private OnlineShopDbContext context = null;
        public ProductModel()
        {
            context = new OnlineShopDbContext();
        }
        public List<Product> listAllPaging()
        {
            var list = context.Database.SqlQuery<Product>("Sp_Product_ListAll").ToList();
            return list;
        }
    }
}
