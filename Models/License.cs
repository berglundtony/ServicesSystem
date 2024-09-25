using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServicesSystem.Models
{

    public class Customer {
        [Key]
        public int CustomerId { get; set;}
        public int AccountId { get; set; }
        public string CompanyName { get; set; }
    }

    public class User
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public int CustomerId { get; set; }
        [JsonIgnore]
        public int LicenseId { get; set; }
        public string UserName { get; set; }
    }

    public class License
    {
        [Key]
        public int LicenseId { get; set; }
        public int AccountId { get; set; }
        public int ServiceId { get; set; }
        public string State { get; set; }
        public int QuantityOfUsers { get; set; }
        public DateTime ValidTo { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
