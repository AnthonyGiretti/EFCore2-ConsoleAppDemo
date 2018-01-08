using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore2
{
    //Business object
    public class Orders
    {
        public Orders() { }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
    }

    public class WorkOrder
    {
        public WorkOrder() { }

        public int WorkOrderId { get; set; }
        public int ProductID { get; set; }
        public int? OrderQty { get; set; }
        public int? StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public short? ScrapReasonID { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Product Product { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ProductDetail Details { get; set; }
    }

    public class ProductDetail
    {
        public int ProductID { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }

        public Product Product { get; set; }
    }
}