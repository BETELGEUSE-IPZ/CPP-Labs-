using lab6_api.Data.DB;
using lab6_api.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly DBContext context;

        public CustomerController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await context.MDMCustomers
                .Join(context.UKPAFFiles,
                    mdm => mdm.PAFAddressId,
                    uk => uk.PafAddressId,
                    (mdm, uk) => new { MDM = mdm, UK = uk })
                .Join(context.ISOCountryCodes,
                    result => result.UK.CountryCode,
                    iso => iso.CountryCode,
                    (result, iso) => new Customer
                    {
                        CustomerId = result.MDM.MDMCustomerId,
                        DateOfBirth = result.MDM.MDMDateOfBirth,
                        OtherDetails = result.MDM.OtherDetails,
                        ISOCountryCode = iso.CountryCode,
                        ISOCountryName = iso.CountryName,
                        Country = result.UK.Country,
                        AddressLine1 = result.UK.AddressLine1,
                        AddressLine2 = result.UK.AddressLine2,
                        AddressLine3 = result.UK.AddressLine3,
                        CityTown = result.UK.CityTown,
                        Postcode = result.UK.Postcode
                    })
                .ToListAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomersById(long id)
        {
            var customer = await context.MDMCustomers
                .Where(mdm => mdm.MDMCustomerId == id)
                .Join(context.UKPAFFiles,
                    mdm => mdm.PAFAddressId,
                    uk => uk.PafAddressId,
                    (mdm, uk) => new { MDM = mdm, UK = uk })
                .Join(context.ISOCountryCodes,
                    result => result.UK.CountryCode,
                    iso => iso.CountryCode,
                    (result, iso) => new Customer
                    {
                        CustomerId = result.MDM.MDMCustomerId,
                        DateOfBirth = result.MDM.MDMDateOfBirth,
                        OtherDetails = result.MDM.OtherDetails,
                        ISOCountryCode = iso.CountryCode,
                        ISOCountryName = iso.CountryName,
                        Country = result.UK.Country,
                        AddressLine1 = result.UK.AddressLine1,
                        AddressLine2 = result.UK.AddressLine2,
                        AddressLine3 = result.UK.AddressLine3,
                        CityTown = result.UK.CityTown,
                        Postcode = result.UK.Postcode
                    })
                .ToListAsync();

            return Ok(customer);
        }

        [HttpGet("between-dates")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersBetweenDates([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var customers = await context.MDMCustomers
                .Where(mdm => mdm.MDMDateOfBirth >= startDate && mdm.MDMDateOfBirth <= endDate)
                .Join(context.UKPAFFiles,
                    mdm => mdm.PAFAddressId,
                    uk => uk.PafAddressId,
                    (mdm, uk) => new { MDM = mdm, UK = uk })
                .Join(context.ISOCountryCodes,
                    result => result.UK.CountryCode,
                    iso => iso.CountryCode,
                    (result, iso) => new Customer
                    {
                        CustomerId = result.MDM.MDMCustomerId,
                        DateOfBirth = result.MDM.MDMDateOfBirth,
                        OtherDetails = result.MDM.OtherDetails,
                        ISOCountryCode = iso.CountryCode,
                        ISOCountryName = iso.CountryName,
                        Country = result.UK.Country,
                        AddressLine1 = result.UK.AddressLine1,
                        AddressLine2 = result.UK.AddressLine2,
                        AddressLine3 = result.UK.AddressLine3,
                        CityTown = result.UK.CityTown,
                        Postcode = result.UK.Postcode
                    })
                .ToListAsync();

            return Ok(customers);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Customer>>> SearchCustomers([FromQuery] string query)
        {
            var customers = await context.MDMCustomers
                .Join(context.UKPAFFiles,
                    mdm => mdm.PAFAddressId,
                    uk => uk.PafAddressId,
                    (mdm, uk) => new { MDM = mdm, UK = uk })
                .Join(context.ISOCountryCodes,
                    result => result.UK.CountryCode,
                    iso => iso.CountryCode,
                    (result, iso) => new Customer
                    {
                        CustomerId = result.MDM.MDMCustomerId,
                        DateOfBirth = result.MDM.MDMDateOfBirth,
                        OtherDetails = result.MDM.OtherDetails,
                        ISOCountryCode = iso.CountryCode,
                        ISOCountryName = iso.CountryName,
                        Country = result.UK.Country,
                        AddressLine1 = result.UK.AddressLine1,
                        AddressLine2 = result.UK.AddressLine2,
                        AddressLine3 = result.UK.AddressLine3,
                        CityTown = result.UK.CityTown,
                        Postcode = result.UK.Postcode
                    })
                .Where(customer =>
                    EF.Functions.Like(customer.OtherDetails, $"%{query}%") ||
                    EF.Functions.Like(customer.ISOCountryCode, $"%{query}%") ||
                    EF.Functions.Like(customer.ISOCountryName, $"%{query}%") ||
                    EF.Functions.Like(customer.Country, $"%{query}%") ||
                    EF.Functions.Like(customer.AddressLine1, $"%{query}%") ||
                    EF.Functions.Like(customer.AddressLine2, $"%{query}%") ||
                    EF.Functions.Like(customer.AddressLine3, $"%{query}%") ||
                    EF.Functions.Like(customer.CityTown, $"%{query}%") ||
                    EF.Functions.Like(customer.Postcode, $"%{query}%"))
                .ToListAsync();

            return Ok(customers);
        }
    }
}
