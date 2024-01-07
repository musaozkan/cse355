using System.ComponentModel.DataAnnotations;

namespace cse355.Models
{
    public class Order_Quantities
    {
        [Key]
        public int QuantityID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
    }

}
