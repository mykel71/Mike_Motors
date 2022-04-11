using MyCarSale.Data;
using MyCarSale.Data.Services;
using MyCarSale.Data.Static;
using MyCarSale.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MakesController : Controller
    {
        private readonly IMakesService _service;

        public MakesController(IMakesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMakes = await _service.GetAllAsync();
            return View(allMakes);
        }

        //GET: make/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var makeDetails = await _service.GetByIdAsync(id);
            if (makeDetails == null) return View("NotFound");
            return View(makeDetails);
        }

        //GET: makes/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Make make)
        {
            if (!ModelState.IsValid) return View(make);

            await _service.AddAsync(make);
            return RedirectToAction(nameof(Index));
        }

        //GET: make/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Make make)
        {
            if (!ModelState.IsValid) return View(make);

            if(id == make.Id)
            {
                await _service.UpdateAsync(id, make);
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        //GET: make/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var makeDetails = await _service.GetByIdAsync(id);
            if (makeDetails == null) return View("NotFound");
            return View(makeDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makeDetails = await _service.GetByIdAsync(id);
            if (makeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
