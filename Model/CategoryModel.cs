using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = null;
        public CategoryModel()
        {
            context = new OnlineShopDbContext();

        }
        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("Sp_Category_ListAll").ToList();
            return list;
        }
        public int Create(string name, bool? status)
        {
            object[] parameters =  {
                new SqlParameter("@Name",name),
                new SqlParameter("@Status",status)
            };

            int res = context.Database.ExecuteSqlCommand("Sp_Category_Insert @Name,@Status", parameters);
        
            return res;
        }
    }
}
