using System.Collections.Generic;

namespace ConsoleAppEFCore2
{
    public interface IEfQueriesDI
    {
        List<Orders> GetOrders();
        Orders GetOrderById(int id);
        List<Product> GetProductsByNameLike(string name);
        Orders GetOrderByIdCompiled(int id);
        int GetProductStock(int productId);
        List<Product> GetProductsWithDetails();
        List<Product> GetProducts();
        List<Person> GetPersons();
    }

}