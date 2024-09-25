using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesSystem.Data;
using ServicesSystem.Migrations;
using ServicesSystem.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using LicenseContext = ServicesSystem.Models.LicenseContext;

namespace ServicesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly LicenseContext licenseContext;
        public AccountController(LicenseContext licenseContext)
        {
            this.licenseContext = licenseContext;
        }

        [HttpGet("{customerId}/")]
        public async Task<IActionResult> GetAccountsByCustomerIdAsync(int customerId)
        {

            var accounts = MockData.Accounts
             .Join(licenseContext.Customers,
               accountInfo => accountInfo.CustomerId,
               customer => customer.CustomerId,
               (accountInfo, customer) => new
               {
                   AccountId = accountInfo.AccountId,
                   CustomerId = customer.CustomerId,
                   CompanyName = customer.CompanyName,
               })
            .Where(customer => customer.CustomerId == customerId)
            .OrderBy(r => r.AccountId)
            .ToList();

            if (!accounts.Any())
                return NotFound("ManagmentAccount not found");
            return Ok(accounts);
        }

        [HttpGet]
        public IActionResult GetSoftwareServices()
        {
            return Ok(MockData.Services);
        }

        [HttpGet("active-licenses-with-services-and-users")]
        public async Task<IActionResult> GetActiveLicensesWithServices()
        {
            var licenses = await licenseContext.Licenses
                .Include(l => l.Users)
                .Where(l => l.State == "active")
                .ToListAsync();

            var result = licenses.Join(MockData.Services,
                license => license.ServiceId,
                service => service.ServiceId,
                (license, service) => new
                {
                    License = license,
                    Service = service

                }).Join(MockData.Accounts,
                licenseService => licenseService.License.AccountId,
                account => account.AccountId,
                (licenseService, account) => new
                {
                    licenseService.License,
                    licenseService.Service,
                    Account = account
                }).Join(licenseContext.Customers,
                accountInfo => accountInfo.Account.CustomerId,
                customer => customer.CustomerId,
                (accountInfo, customer) => new
                {
                    LicenseId = accountInfo.License.LicenseId,
                    AccountId = accountInfo.Account.AccountId,
                    CustomerId = customer.CustomerId,
                    CompanyName = customer.CompanyName,
                    SoftwareName = accountInfo.Service.SoftwareName,
                    Price = accountInfo.Service.Price,
                    Users = accountInfo.License.Users.Select(u => new
                    {
                        UserId = u.UserId,
                        UserName = u.UserName,
                        CustomerId = u.CustomerId
                    }),
                    accountInfo.License.State,
                    accountInfo.License.QuantityOfUsers,
                    accountInfo.License.ValidTo
                }).OrderBy(r => r.CustomerId).ToList();

            return Ok(result);
        }


        [HttpGet("inactive-licenses-with-services")]
        public async Task<IActionResult> GetInactiveLicensesWithServices()
        {
            var licenses = await licenseContext.Licenses
                .Include(l => l.Users)
                .Where(l => l.State == "inactive")
                .ToListAsync();

            var result = licenses.Join(MockData.Services,
                license => license.ServiceId,
                service => service.ServiceId,
                (license, service) => new
                {
                    License = license,
                    Service = service

                }).Join(MockData.Accounts,
                 licenseService => licenseService.License.AccountId,
                account => account.AccountId,
                   (licenseService, account) => new
                   {
                       licenseService.License,
                       licenseService.Service,
                       Account = account
                   }).Join(licenseContext.Customers,
                   accountInfo => accountInfo.Account.CustomerId,
                   customer => customer.CustomerId,
                   (accountInfo, customer) => new
                   {
                       LicenseId = accountInfo.License.LicenseId,
                       AccountId = accountInfo.Account.AccountId,
                       CustomerId = customer.CustomerId,
                       CompanyName = customer.CompanyName,
                       SoftwareName = accountInfo.Service.SoftwareName,
                       Price = accountInfo.Service.Price,
                       Users = accountInfo.License.Users.Select(u => new
                       {
                           UserId = u.UserId,
                           UserName = u.UserName,
                           CustomerId = u.CustomerId
                       }),
                       accountInfo.License.State,
                       accountInfo.License.QuantityOfUsers,
                       accountInfo.License.ValidTo
                   }).OrderBy(r => r.CustomerId).ToList();

            return Ok(result);
        }


        [HttpPost("/{accountId}/order")]
        public async Task<IActionResult> OrderSoftwareServiceAsync(int accountId, [FromBody] OrderSoftwareServiceRequest request)
        {
            var account = await MockData.GetAccountByIdAsync(accountId);
            if (account == null)
                return NotFound("Account not found");

            var service = await MockData.GetServicesAsync(request.ServiceId);
            if (service == null)
                return NotFound("Service not found");

            var license = new Models.License
            {
                AccountId = accountId,
                ServiceId = request.ServiceId,
                QuantityOfUsers = request.QuantityOfUsers,
                State = "active",
                ValidTo = DateTime.Now.AddMonths(6),
                Users = new List<User>()
            };

            var lastLicenceId = licenseContext.Licenses
                .OrderByDescending(u => u.LicenseId)   // Sortera efter UserId i fallande ordning
                .Select(u => u.LicenseId)              // Välj endast UserId
                .FirstOrDefault();

            // Add users to the license
            foreach (var userRequest in request.Users)
            {
                var user = new User
                {
                    CustomerId = account.CustomerId,
                    LicenseId = lastLicenceId + 1,
                    UserName = userRequest.UserName,
                };

                license.Users.Add(user); // Associate the new user with the license
            }

            licenseContext.Licenses.Add(license);
            await licenseContext.SaveChangesAsync();

            var present = new
            {
                AccountId = accountId,
                Users = new List<User> { license.Users.First() },
                ServiceId = request.ServiceId,
                SoftwareName = service.SoftwareName,
                QuantityOfUsers = request.QuantityOfUsers,
                State = "active",
                ValidTo = DateTime.Now.AddMonths(6)
            };
            return Ok(new
            {
                present,
            });
        }


        [HttpPost("add-users/{licenseId}")]
        public async Task<IActionResult> AddUsersToLicense(int licenseId, [FromBody] List<UserRequest> userRequests)
        {
            var license = await licenseContext.Licenses.Include(l => l.Users).FirstOrDefaultAsync(l => l.LicenseId == licenseId);

            if (license == null)
            {
                return NotFound("License not found");
            }

            // Skapa nya användarobjekt från inkommande data
            foreach (var userRequest in userRequests)
            {
                var user = new User
                {
                    CustomerId = userRequest.CustomerId,
                    UserName = userRequest.UserName,
                };

                license.Users.Add(user);
            }

            await licenseContext.SaveChangesAsync();

            return Ok(new
            {
                LicenseId = license.LicenseId,
                Users = license.Users.Select(u => new { u.UserId, u.UserName })
            });
        }

        [HttpPut("accounts/{licenseId}/change-quantity")]
        public IActionResult ChangeLicenseQuantity(int licenseId, [FromBody] int newQuantity)
        {
            var license = licenseContext.Licenses.Where(a => a.LicenseId == licenseId).FirstOrDefault();
            license.QuantityOfUsers = newQuantity;
            licenseContext.Licenses.Update(license);
            licenseContext.SaveChanges();
            return Ok(license);
        }


        [HttpPut("accounts/{licenseId}/change-state")]
        public IActionResult ChangeStateLicense(int licenseId)
        {
            var license = licenseContext.Licenses.Where(a => a.LicenseId == licenseId).FirstOrDefault();
            if (license == null)
            {
                return NotFound($"License for account with ID {license} not found.");
            }
            license.State = (license.State == "active") ? "inactive" : "active";

            licenseContext.Licenses.Update(license);
            licenseContext.SaveChanges();
            return Ok(license);
        }

        [HttpPut("accounts/{accountId}/extend-date")]
        public IActionResult ExtendTheValidDateOneMoreMounth(int accountId)
        {
            var license = licenseContext.Licenses.Where(a => a.AccountId == accountId).FirstOrDefault();
            if (license == null)
            {
                return NotFound($"License for account with ID {accountId} not found.");
            }
            license.ValidTo = license.ValidTo.AddMonths(1);
            licenseContext.Licenses.Update(license);
            licenseContext.SaveChanges();
            return Ok(license);
        }
    }
}
