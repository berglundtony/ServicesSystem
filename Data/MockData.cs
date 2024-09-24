using Microsoft.Identity.Client;
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
            new Account { AccountId = 4, CustomerId = 1, Licenses = new List<License>() }
        };

        public static List<SoftwareService> Services = new List<SoftwareService>
        {
            new SoftwareService { ServiceId = 1, SoftwareName = "Office", Price = 600 },
            new SoftwareService { ServiceId = 2, SoftwareName = "CreativeSuite", Price = 1500 },
            new SoftwareService { ServiceId = 3, SoftwareName = "VismaControl", Price = 800 },
            new SoftwareService { ServiceId = 4, SoftwareName = "Fortnox", Price = 1200 }
        };

        // Asynchronous method to get accounts
        public static async Task<List<Account>> GetAccountsAsync()
        {
            return await Task.FromResult(Accounts);
        }

        // Simulate an asynchronous operation with delay
        public static async Task<Account> GetAccountByIdAsync(int accountId)
        {
            await Task.Delay(500); // Simulate a delay, like a database query
            return Accounts.Find(a => a.AccountId == accountId);
        }

        // Asynchronous method to get services
        public static async Task<SoftwareService> GetServicesAsync(int serviceId)
        {
            await Task.Delay(500); // Simulate a delay, like a database query
            return Services.Find(s => s.ServiceId == serviceId);
        }

        // Asynchronous method to get services
        public static async Task<List<SoftwareService>> GetServicesAsync(Func<object, bool> value)
        {
            return await Task.FromResult(Services);
        }


    }
}
