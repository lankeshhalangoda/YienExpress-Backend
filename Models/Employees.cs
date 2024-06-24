namespace backend.Models
{
    public class Employees
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public long PhoneNo { get; set; }
    }
}
