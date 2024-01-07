namespace cse355.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Material { get; set; }
        public string VerticalSectionType { get; set; }
        public string VerticalSectionSize { get; set; }
        public string Alloy { get; set; }
        public double SpecificWeightInKG { get; set; }  
        public int LengthInMeters { get; set; }
        public double WeightOnePieceInKG { get; set; }  
        public int UnitPrice { get; set; }
    }
}
