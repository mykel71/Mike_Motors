using MyCarSale.Data;
using MyCarSale.Data.Services;
using MyCarSale.Data.Static;
using MyCarSale.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ModelsController : Controller
    {
        private readonly IModelsService _service;

        public ModelsController(IModelsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: model/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Model model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _service.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        //Get: model/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var modelDetails = await _service.GetByIdAsync(id);

            if (modelDetails == null) return View("NotFound");
            return View(modelDetails);
        }

        //Get: model/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var modelDetails = await _service.GetByIdAsync(id);
            if (modelDetails == null) return View("NotFound");
            return View(modelDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Model model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _service.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        //Get: models/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var modelDetails = await _service.GetByIdAsync(id);
            if (modelDetails == null) return View("NotFound");
            return View(modelDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelDetails = await _service.GetByIdAsync(id);
            if (modelDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
