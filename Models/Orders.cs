namespace backend.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }    
        public string ParcelName { get; set; }
        public long PhoneNo { get; set; }
        public string Status { get; set; }

    }
}
