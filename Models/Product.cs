namespace cse355.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Material { get; set; }
        public string VerticalSectionType { get; set; }
        public string VerticalSectionSize { get; set; }
        public string Alloy { get; set; }
        public decimal SpecificWeightInKG { get; set; }
        public decimal LengthInMeters { get; set; }
        public decimal WeightOnePieceInKG { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
