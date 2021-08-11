using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract;
using Northwind.Entities;

namespace Northwind.Dal.Concrete.EntityFramework
{
   public class EfProductDal:IProductDal
   {
       private readonly NorthwindContext _context = new NorthwindContext();


       public List<Product> GetAll()
       {
           return _context.Products.ToList();
       }

       public Product Get(int productId)
       {
           return _context.Products.FirstOrDefault((p => p.ProductID == productId));
       }

        public void Add(Product product)
        { _context.Products.Add(product); 
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault((p => p.ProductID == productId)));
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault((p => p.ProductID == product.ProductID));
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductID = product.ProductID;

            _context.SaveChanges();
        }   
    }
}
