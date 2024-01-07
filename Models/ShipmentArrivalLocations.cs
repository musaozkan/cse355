using System.ComponentModel.DataAnnotations;

namespace cse355.Models
{
    public class ShipmentArrivalLocations
    {
        [Key]
        public int ShipmentID { get; set; }
        public int ArrivalLocationID { get; set; }
        public string ArrivalLocation { get; set; }
    }

}
