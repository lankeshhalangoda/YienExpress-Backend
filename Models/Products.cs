namespace backend.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string OrderID { get; set; }
        public string Name { get; set; }
        public long WeightInGrams { get; set; }

        public string Condition { get; set; }
    }
}
