using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServicesSystem.Models
{

    public class Customer {
        [Key]
        public int CustomerId { get; set;}
        public string CompanyName { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public ICollection<License> Licenses { get; set; }
    }

    public class LicenseUser
    {
        public int LicenseLicenseId { get; set; }
        public int LicenseId { get; set; }
        public int UserId { get; set; }
    }

    public class License
    {
        [Key]
        public int LicenseId { get; set; }
        public int AccountId { get; set; }
        public string SoftwareName { get; set; }
        public string State { get; set; }
        public int QuantityOfUsers { get; set; }
        public DateTime ValidTo { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
