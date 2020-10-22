using BlindLowVisionProject.Models;
using BlindLowVisionProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlindLowVisionProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ICustomerRepository customerRepository,
                                   IHostingEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var model = _customerRepository.GetAllCustomers();
            return View(model);
        }       
        public ViewResult Details(int? id, string name)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Customer = _customerRepository.GetCustomer(1),
                PageTitle = "Customer Details"
            };
            
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Customer customer = _customerRepository.GetCustomer(id);
            CustomerEditViewModel customerEditViewModel = new CustomerEditViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Department = customer.Department,
                ExistingPhotoPath = customer.PhotoPath
            };
            return View(customerEditViewModel);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Customer newCustomer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _customerRepository.Add(newCustomer);
                return RedirectToAction("details", new { id = newCustomer.Id });
            }

            return View();
        }
    }
}
