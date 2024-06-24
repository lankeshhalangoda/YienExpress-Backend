namespace backend.Models
{
    public class Customers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long PhoneNo { get; set; }
    }
}
