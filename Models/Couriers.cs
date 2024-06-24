namespace backend.Models
{
    public class Couriers
    {
        public Guid Id { get; set; }
        public string CourierName { get; set; }
        public string Address { get; set; }
        public string Continent { get; set; }
        public long PhoneNo { get; set; }
    }
}
