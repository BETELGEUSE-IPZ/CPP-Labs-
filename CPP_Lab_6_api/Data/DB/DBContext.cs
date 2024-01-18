using lab6_api.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace lab6_api.Data.DB
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GenerateISOCountryCodeModel(modelBuilder);
            GenerateUKPafFileModel(modelBuilder);
            GenerateMDMCustomerModel(modelBuilder); 
            GenerateMDMServices(modelBuilder);
            GenerateCustomerSystems(modelBuilder);
            GenerateMDMCustomerIndex(modelBuilder);
            GenerateMDMCustomersServices(modelBuilder);
            GenerateMDMPayments(modelBuilder);
            GenerateCouncilTax(modelBuilder);
            GenerateHousingBenefits(modelBuilder);
            GenerateSocialServices(modelBuilder);
            GenerateElectoralRegister(modelBuilder);
            GenerateParkingTickets(modelBuilder);
            GenerateParkingPayments(modelBuilder);
        }

        private void GenerateISOCountryCodeModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ISOCountryCode>().HasKey(e => e.CountryCode);
            modelBuilder.Entity<ISOCountryCode>().HasData(
                new ISOCountryCode { CountryCode = "UA", CountryName = "Ukraine" },
                new ISOCountryCode { CountryCode = "GB", CountryName = "United Kingdom" },
                new ISOCountryCode { CountryCode = "US", CountryName = "United States of America" },
                new ISOCountryCode { CountryCode = "ES", CountryName = "Spain" },
                new ISOCountryCode { CountryCode = "CA", CountryName = "Canada" }
            );
        }

        private void GenerateUKPafFileModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UKPAFFile>().HasKey(e => e.PafAddressId);
            modelBuilder.Entity<UKPAFFile>().HasData(
                new UKPAFFile { PafAddressId = 1, CountryCode = "UA", AddressLine1 = "Shevchenko Street", AddressLine2 = "Apt 56", AddressLine3 = "Building 1", CityTown = "Kyiv", Postcode = "01001", Country = "Ukraine" },
                new UKPAFFile { PafAddressId = 2, CountryCode = "UA", AddressLine1 = "Vasylkyvska Street", AddressLine2 = "Apt 2", AddressLine3 = "Building 2", CityTown = "Kyiv", Postcode = "03036", Country = "Ukraine" },
                new UKPAFFile { PafAddressId = 3, CountryCode = "US", AddressLine1 = "Main Street", AddressLine2 = "Suite 100", AddressLine3 = "Building 3", CityTown = "New York", Postcode = "10001", Country = "USA" },
                new UKPAFFile { PafAddressId = 4, CountryCode = "GB", AddressLine1 = "High Street", AddressLine2 = "Flat 5", AddressLine3 = "Building 4", CityTown = "London", Postcode = "SW1A 1AA", Country = "UK" },
                new UKPAFFile { PafAddressId = 5, CountryCode = "CA", AddressLine1 = "Queen Street", AddressLine2 = "Unit 3", AddressLine3 = "Building 5", CityTown = "Toronto", Postcode = "M5H 2M9", Country = "Canada" }
            );
        }

        private void GenerateMDMCustomerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDMCustomer>().HasKey(e => e.MDMCustomerId);
            modelBuilder.Entity<MDMCustomer>().HasData(
                new MDMCustomer { MDMCustomerId = 1, PAFAddressId = 1, MDMDateOfBirth = new DateTime(2000, 5, 15), OtherDetails = "" },
                new MDMCustomer { MDMCustomerId = 2, PAFAddressId = 2, MDMDateOfBirth = new DateTime(2002, 6, 1), OtherDetails = "" },
                new MDMCustomer { MDMCustomerId = 3, PAFAddressId = 3, MDMDateOfBirth = new DateTime(1983, 2, 2), OtherDetails = "" },
                new MDMCustomer { MDMCustomerId = 4, PAFAddressId = 4, MDMDateOfBirth = new DateTime(1967, 11, 15), OtherDetails = "" },
                new MDMCustomer { MDMCustomerId = 5, PAFAddressId = 5, MDMDateOfBirth = new DateTime(1999, 9, 6), OtherDetails = "" }
            );
        }

        private void GenerateMDMServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDMServices>().HasKey(e => e.ServiceId);
            modelBuilder.Entity<MDMServices>().HasData(
                new MDMServices { ServiceId = 1, ServiceCategoryCode = 1, ServiceName = "Pay Parking Fine", ServiceCost = 20, ServiceDescription = "Pay the fine that was issued for parking in the prohibited zone" },
                new MDMServices { ServiceId = 2, ServiceCategoryCode = 2, ServiceName = "Pay Customs Cleareance Taxes", ServiceCost = 50, ServiceDescription = "Pay the fixed tax for customs clearence service" }
            );
        }

        private void GenerateCustomerSystems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerSystems>().HasKey(e => e.SystemCode);
            modelBuilder.Entity<CustomerSystems>().HasData(
                new CustomerSystems { SystemCode = 1, SystemName = "Parking system" },
                new CustomerSystems { SystemCode = 2, SystemName = "Customs system" }
            );
        }

        private void GenerateMDMCustomerIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDMCustomerIndex>().HasKey(e => e.MDMCustomerId);
            modelBuilder.Entity<MDMCustomerIndex>().HasData(
                new MDMCustomerIndex { MDMCustomerId = 1, SystemCode = 1, SystemCustomerId = 1 },
                new MDMCustomerIndex { MDMCustomerId = 2, SystemCode = 2, SystemCustomerId = 2 }
            );
        }

        private void GenerateMDMCustomersServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDMCustomersServices>().HasKey(e => e.CustomersServiceId);
            modelBuilder.Entity<MDMCustomersServices>().HasData(
                new MDMCustomersServices { CustomersServiceId = 1, MDMCustomerId = 1, ServiceId = 1, DateServiceRequested = new DateTime(2023, 11, 21), DateServiceReceived = new DateTime(2023, 11, 22), CostOfService = 20 },
                new MDMCustomersServices { CustomersServiceId = 2, MDMCustomerId = 2, ServiceId = 2, DateServiceRequested = new DateTime(2023, 11, 16), DateServiceReceived = new DateTime(2023, 11, 17), CostOfService = 50 }
            );
        }

        private void GenerateMDMPayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDMPayments>().HasKey(e => e.MDMPaymentId);
            modelBuilder.Entity<MDMPayments>().HasData(
                new MDMPayments { MDMPaymentId = 1, CustomersServiceId = 1, PaymentMethodCode = 1, PaymentStatusCode = 1, DateOfPayment = new DateTime(2023, 11, 21), AmountOfPayment = 20 },
                new MDMPayments { MDMPaymentId = 2, CustomersServiceId = 2, PaymentMethodCode = 2, PaymentStatusCode = 2, DateOfPayment = new DateTime(2023, 11, 16), AmountOfPayment = 50 }
            );
        }

        public void GenerateCouncilTax(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouncilTax>().HasKey(e => e.CTResidentId);
            modelBuilder.Entity<CouncilTax>().HasData(
                new CouncilTax { CTResidentId = 1, CTAddressLine1 = "Shevchenko Street", CTAddressLine2 = "Apt 56", CTAddressLine3 = "Building 1", CTCityTown = "Kyiv", CTPostcode = "01001" },
                new CouncilTax { CTResidentId = 2, CTAddressLine1 = "Vasylkyvska Street", CTAddressLine2 = "Apt 2", CTAddressLine3 = "Building 2", CTCityTown = "Kyiv", CTPostcode = "03036" }
            );
        }

        private void GenerateHousingBenefits(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HousingBenefits>().HasKey(e => e.HBRecipientId);
            modelBuilder.Entity<HousingBenefits>().HasData(
                new HousingBenefits { HBRecipientId = 1, HBAddress = "Shevchenko St., Apt 56, Building 1", HBPostcode = "01001" },
                new HousingBenefits { HBRecipientId = 2, HBAddress = "Vasylkyvska St., Apt 2, Building 2", HBPostcode = "03036" }
            );
        }

        private void GenerateSocialServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialServices>().HasKey(e => e.SSClientId);
            modelBuilder.Entity<SocialServices>().HasData(
                new SocialServices { SSClientId = 1 },
                new SocialServices { SSClientId = 2 }
            );
        }

        private void GenerateElectoralRegister(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectoralRegister>().HasKey(e => e.ERVoterId);
            modelBuilder.Entity<ElectoralRegister>().HasData(
                new ElectoralRegister { ERVoterId = 1, ERAddressLine1 = "Shevchenko Street", ERAddressLine2 = "Apt 56", ERCityTown = "Kyiv", ERPostcode = "01001" },
                new ElectoralRegister { ERVoterId = 2, ERAddressLine1 = "Vasylkyvska Street", ERAddressLine2 = "Apt 2", ERCityTown = "Kyiv", ERPostcode = "03036" }
            );
        }

        private void GenerateParkingTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingTickets>().HasKey(e => e.PTOffenderId);
            modelBuilder.Entity<ParkingTickets>().HasData(
                new ParkingTickets { PTOffenderId = 1, PTAddress = "Shevchenko St., Building 1" },
                new ParkingTickets { PTOffenderId = 2, PTAddress = "Vasylkyvska St., Building 2" }
            );
        }

        private void GenerateParkingPayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingPayments>().HasKey(e => e.PaymentId);
            modelBuilder.Entity<ParkingPayments>().HasData(
                new ParkingPayments { PaymentId = 1, PTOffenderId = 1, PaymentMethodCode = 1, DateOfPayment = new DateTime(2023, 11, 21), AmountOfPayment = 20 },
                new ParkingPayments { PaymentId = 2, PTOffenderId = 2, PaymentMethodCode = 2, DateOfPayment = new DateTime(2023, 11, 16), AmountOfPayment = 50 }
            );
        }

        public DbSet<ISOCountryCode> ISOCountryCodes { get; set; }

        public DbSet<UKPAFFile> UKPAFFiles { get; set; }

        public DbSet<MDMCustomer> MDMCustomers { get; set; }

        public DbSet<MDMServices> MDMServices { get; set; }

        public DbSet<CustomerSystems> CustomerSystems { get; set; } 

        public DbSet<MDMCustomerIndex> MDMCustomerIndices { get; set; }

        public DbSet<MDMCustomersServices> MDMCustomersServices { get; set; }

        public DbSet<MDMPayments> MDMPayments { get; set; }  

        public DbSet<CouncilTax> CouncilTaxes { get; set; } 

        public DbSet<HousingBenefits> HousingBenefits { get; set; }

        public DbSet<SocialServices> SocialServices { get; set; }

        public DbSet<ElectoralRegister> ElectoralRegisters { get; set; }

        public DbSet<ParkingTickets> ParkingTickets { get; set; }

        public DbSet<ParkingPayments> ParkingPayments { get; set; }
    }
}