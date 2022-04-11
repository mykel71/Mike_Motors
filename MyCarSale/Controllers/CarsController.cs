using MyCarSale.Data;
using MyCarSale.Data.Services;
using MyCarSale.Data.Static;
using MyCarSale.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCars = await _service.GetAllAsync();
            return View(allCars);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCars = await _service.GetAllAsync(/*n => n.Producer*/);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allCars.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allCars.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allCars);
        }

        //GET: Cars/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var carDetail = await _service.GetCarByIdAsync(id);
            return View(carDetail);
        }

        //GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            var carDropdownsData = await _service.GetNewCarDropdownsValues();

            ViewBag.Cars = new SelectList(carDropdownsData.Makes, "Id", "FullName");
            ViewBag.Models = new SelectList(carDropdownsData.Models, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCarVM car)
        {
            if (!ModelState.IsValid)
            {
                var carDropdownsData = await _service.GetNewCarDropdownsValues();

                ViewBag.Makes = new SelectList(carDropdownsData.Makes, "Id", "FullName");
                ViewBag.Model = new SelectList(carDropdownsData.Models, "Id", "FullName");

                return View(car);
            }

            await _service.AddNewCarAsync(car);
            return RedirectToAction(nameof(Index));
        }


        //GET: Cars/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _service.GetCarByIdAsync(id);
            if (carDetails == null) return View("NotFound");

            var response = new NewCarVM()
            {
                Id = carDetails.Id,
                Name = carDetails.Name,
                Model = carDetails.Model,
                Year = carDetails.Year,
                Color = carDetails.Color,
                Mileage = carDetails.Mileage,
                Description = carDetails.Description,
                Price = carDetails.Price,
                ImageURL = carDetails.ImageURL,
                CarCategory = carDetails.CarCategory,
            };

            var movieDropdownsData = await _service.GetNewCarDropdownsValues();
            ViewBag.Makes = new SelectList(movieDropdownsData.Makes, "Id", "FullName");
            ViewBag.Models = new SelectList(movieDropdownsData.Models, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCarVM car)
        {
            if (id != car.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var carDropdownsData = await _service.GetNewCarDropdownsValues();

                ViewBag.Makes = new SelectList(carDropdownsData.Makes, "Id", "FullName");
                ViewBag.Models = new SelectList(carDropdownsData.Models, "Id", "FullName");

                return View(car);
            }

            await _service.UpdateCarAsync(car);
            return RedirectToAction(nameof(Index));
        }
    }
}