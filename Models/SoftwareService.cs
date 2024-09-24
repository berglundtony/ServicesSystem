using System.Text.Json.Serialization;

namespace ServicesSystem.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public List<License> Licenses { get; set; }
    }
    public class SoftwareService
    {
        public int ServiceId { get; set; }
        public string SoftwareName { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderSoftwareServiceRequest
    {
        public int ServiceId { get; set; }
        public int QuantityOfUsers { get; set; }
        public List<User> Users { get; set; } 
    }

    public class UserRequest
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public string UserName { get; set; }
    }
}