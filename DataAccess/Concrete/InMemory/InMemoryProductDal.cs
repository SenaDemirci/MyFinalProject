using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    //bellekle çalışır (veritabanıyla değil)
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //class içinde metotların dışında tanımlanan değişkenler class içinde global değişken olur.
                                 //Bu yüzden _ ile tanımlanır.
        public InMemoryProductDal() //constructor oluştururken ctor yazıp tab tab yapılır
        {
            _products = new List<Product> { //ürün listesi oluşturur(bilgiler normalde bir veri tabanından alınır)
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak", UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=1,ProductId=2,ProductName="Kamera", UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=2,ProductId=2,ProductName="Telefon", UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=2,ProductId=4,ProductName="Klavye", UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=2,ProductId=5,ProductName="Fare", UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ kullanmadan silme işlemi
            Product productToDelete = null; //silinecek eleman
                                            //liste olduğu için null verilir(referans no su olmasın, bellekte boş yer kaplamasın diye new lemedik)
            foreach (var p in _products)
            {
                if (product.ProductId==p.ProductId)
                {
                    productToDelete = p;
                }
            }
            _products.Remove(productToDelete); //eleman silinir

            //LINQ - Language Integrated Query kullanarak
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //_products ı tek tek dolaşır
            _products.Remove(productToDelete); //eleman silinir
        }

        public Product GetById(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //içindeki şarta uyan bütün elemanları yeni bir lise haline getirir ve onu döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
