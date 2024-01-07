using System.ComponentModel.DataAnnotations;

namespace cse355.Models
{
    public class Truck
    {
        [Key]
        public int VehicleID { get; set; }
        public decimal WeightCap { get; set; }
        public decimal LengthCap { get; set; }
    }

}
