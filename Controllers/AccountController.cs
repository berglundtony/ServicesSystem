using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSystem.Data;
using ServicesSystem.Models;
using Swashbuckle.AspNetCore.Annotations;
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

        [HttpGet("/{customerId}")]
        public IActionResult GetAccountsByCustomerId(int customerId)
        {
            var accounts = MockData.Accounts.FirstOrDefault(a => a.CustomerId == customerId);
            if (accounts == null)
                return NotFound("ManagmentAccount not found");
            return Ok(accounts);
        }
        [HttpGet]
        public IActionResult GetSoftwareServices()
        {
            return Ok(MockData.Services);
        }

        [HttpPost("/{accountId}/order")]
        public IActionResult OrderSoftwareService(int accountId, [FromBody] OrderSoftwareServiceRequest request)
        {
            var account = MockData.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
                return NotFound("Account not found");

            var service = MockData.Services.FirstOrDefault(s => s.ServiceId == request.ServiceId);
            if (service == null)
                return NotFound("Service not found");

            var license = new Models.License
            {
                SoftwareName = service.SoftwareName,
                QuantityOfUsers = request.QuantityOfUsers,
                State = "active",
                ValidTo = DateTime.Now.AddMonths(6)
            };

            licenseContext.Licenses.Add(license);
            licenseContext.SaveChanges();
            return Ok(license);
        }

        [HttpGet("{accountId}/licenses")]
        public ActionResult<List<Models.License>> SeeLicenses(int accountId)
        {
            var licenses = licenseContext.Licenses.Where(a => a.AccountId == accountId).ToList();
            return Ok(licenses);
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

        [HttpPut("accounts/{accountId}/change-state")]
        public IActionResult CancelLicense(int accountId)
        {
            var license = licenseContext.Licenses.Where(a => a.AccountId == accountId).FirstOrDefault();
            if (license == null)
            {
                return NotFound($"License for account with ID {accountId} not found.");
            }
            license.State = "inactive";
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
