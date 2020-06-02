using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int productId)
        {
            var obj = new Product();
            return _db.Products
                    .Include(u => u.Category)
                    .FirstOrDefault(u => u.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(u => u.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product objProduct)
        {
            _db.Products.Add(objProduct);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product objProduct)
        {
            var existingPrtoduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);

            if (existingPrtoduct != null)
            {
                if (objProduct.Image == null)
                {
                    objProduct.Image = existingPrtoduct.Image;
                }

                _db.Products.Update(objProduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(Product objProduct)
        {
            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);

            if (existingProduct != null)
            {
                _db.Products.Remove(existingProduct);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
