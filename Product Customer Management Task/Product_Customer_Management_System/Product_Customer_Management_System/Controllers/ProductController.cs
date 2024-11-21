using Microsoft.Ajax.Utilities;
using Product_Customer_Management_System.DTOs;
using Product_Customer_Management_System.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Customer_Management_System.Controllers
{
    public class ProductController : Controller
    {
        Product_CustomerEntities db = new Product_CustomerEntities();

        public static Product convert(ProductDTO p)
        {
            return new Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category
            };
        }   
        public static ProductDTO convert(Product p)
        {
            return new ProductDTO
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category
            };
        }
        public static List<ProductDTO> convert(List<Product> products)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (var p in products)
            {
                productDTOs.Add(convert(p));
            }
            return productDTOs;
        }
        // GET: Product
        public ActionResult ProductList()
        {
            var products = db.Products.ToList();
            return View(convert(products));
        }
        [HttpGet]
        public ActionResult ProductCreate() {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(convert(productDTO));
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(productDTO);
        }
    }
}