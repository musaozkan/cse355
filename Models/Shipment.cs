namespace cse355.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public string TrackingInformation { get; set; }
    }

}
