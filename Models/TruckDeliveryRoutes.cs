using System.ComponentModel.DataAnnotations;

namespace cse355.Models
{
    public class TruckDeliveryRoutes
    {
        
        public int VehicleID { get; set; }
        [Key]
        public int DeliveryRouteID { get; set; }
        public string DeliveryRoute { get; set; }
    }

}
