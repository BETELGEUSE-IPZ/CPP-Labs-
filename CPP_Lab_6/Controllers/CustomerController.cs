using lab6.Data;
using lab6.Models;
using lab6.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lab6.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApiDataSource apiDataSource;

        public CustomerController(ApiDataSource apiDataSource)
        {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult Customer()
        {
            var list = apiDataSource.GetCustomersAsync().Result;
            return View(
                new CustomerModel
                {
                    Customers = list
                }
            );
        }

        [HttpPost]
        public IActionResult Customer(CustomerModel model)
        {
            List<Customer> list;
            if (model.IdToSearch != 0) 
            {
                list = apiDataSource.GetCustomersAsync(model.IdToSearch).Result;
            }
            else if (model.DateStart != null)
            {
                list = apiDataSource.GetCustomersByDatesAsync(model.DateStart, model.DateEnd).Result;
            }
            else if (model.Query != null)
            {
                list = apiDataSource.GetCustomersByQueryAsync(model.Query).Result;
            }
            else
            {
                list = new List<Customer>();
            }

            return View(
                new CustomerModel
                {
                    Customers = list
                }
            );
        }
    }
}
