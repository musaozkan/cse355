using System.ComponentModel.DataAnnotations;

namespace cse355.Models
{
    public class Order_OrderedProduct
    {
        [Key]
        public int OrderID { get; set; }
        public int OrderedProductID { get; set; }
        public string OrderedProduct { get; set; }
        
    }

}
