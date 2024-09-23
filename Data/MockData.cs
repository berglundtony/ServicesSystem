using ServicesSystem.Models;

namespace ServicesSystem.Data
{
    public static class MockData
    {
        public static List<Account> Accounts = new List<Account>
        {
            new Account { AccountId = 1, CustomerId = 1, Licenses = new List<License>() },
            new Account { AccountId = 2, CustomerId = 2, Licenses = new List<License>() },
            new Account { AccountId = 3, CustomerId = 3, Licenses = new List<License>() },
        };

        public static List<SoftwareService> Services = new List<SoftwareService>
        {
            new SoftwareService { ServiceId = 1, SoftwareName = "Office", Price = 600 },
            new SoftwareService { ServiceId = 2, SoftwareName = "CreativeSuite", Price = 1500 },
            new SoftwareService { ServiceId = 3, SoftwareName = "VismaControl", Price = 800 }
        };
    }
}
