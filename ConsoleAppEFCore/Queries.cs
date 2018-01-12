using ConsoleAppEFCore2.ScalarFunctions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppEFCore2
{
    public class EfQueriesDI : IEfQueriesDI
    {
        private AdventureWorksContextDI _context;

        private static Func<AdventureWorksContextDI, int, Orders> _getOrderById =
                            EF.CompileQuery((AdventureWorksContextDI context, int id) =>
                            context.WorkOrders.Select(
                                x => new Orders
                                {
                                    Id = x.WorkOrderId,
                                    ProductName = x.Product.Name,
                                    Quantity = x.OrderQty,
                                    Date = x.DueDate
                                }).FirstOrDefault(x => x.Id == id));

        public EfQueriesDI(AdventureWorksContextDI context)
        {
            _context = context;
        }

        public List<Orders> GetOrders()
        {
            var query = _context.WorkOrders.Select(
                    x => new Orders
                    {
                        Id = x.WorkOrderId,
                        ProductName = x.Product.Name,
                        Quantity = x.OrderQty,
                        Date = x.DueDate
                    }).Take(500);

                return query.ToList();  
        }

        public Orders GetOrderById(int id)
        {
            return _context.WorkOrders.Select(
                    x => new Orders
                    {
                        Id = x.WorkOrderId,
                        ProductName = x.Product.Name,
                        Quantity = x.OrderQty,
                        Date = x.DueDate
                    }).FirstOrDefault(x => x.Id == id);
        }

        public List<WorkOrder> GetWorkOrdersByScrapReasonID(int scrapReasonId)
        {
            var query = _context.WorkOrders.FromSql($"SELECT * FROM Production.WorkOrder WHERE ScrapReasonID = {scrapReasonId}");

            return query.ToList();
        }

        public void UpdateWorkOrdersByScrapReasonID(int scrapReasonId,int qty)
        {
            _context.Database.ExecuteSqlCommand($"UPDATE Production.WorkOrder SET OrderQty = {qty} WHERE ScrapReasonID = {scrapReasonId}");
        }

        public List<Product> GetProductsByNameLike(string name)
        {
            var query = _context.Products.Where(x => EF.Functions.Like(x.Name, $"%{name}%"));

            return query.ToList();
        }

        public Orders GetOrderByIdCompiled(int id)
        {
            return _getOrderById(_context, id);

        }

        public int GetProductStock(int productId)
        {
            // Microsoft Doc
            var query = _context.Products
                                .Where(x => x.ProductID == productId)
                                .Select(d => AdventureWorksContextDI.GetProductStock(d.ProductID));

            // Exemple of externalized in static class as static function
            query = _context.Products
                                .Where(x => x.ProductID == productId)
                                .Select(d=> ScalarFunctionsHelpers.GetProductStock(d.ProductID));

            // Exemple of externalized in static class as extension method
            query = _context.Products
                                .Where(x => x.ProductID == productId)
                                .Select(d => d.GetProductStock(d.ProductID));

            return query.FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            var query = _context.Products.Take(10);

            return query.ToList();
        }

        public List<Product> GetProductsWithDetails()
        {
            var query = _context.Products.Include(p=> p.Details).Take(10);

            return query.ToList();
        }

        public List<Person> GetPersons()
        {
            var query = _context.Persons.Take(10);

            return query.ToList();
        }

    }
}
