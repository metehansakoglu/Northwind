using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.WcfLibary.Concrete
{
    public class CategoryService:ICategoryService
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        public List<Category> GetAll()
        {
            return _categoryManager.GetAll();
        }
    }
}
