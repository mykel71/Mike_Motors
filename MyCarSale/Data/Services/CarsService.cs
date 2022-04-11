using MyCarSale.Data.Base;
using MyCarSale.Data.ViewModels;
using MyCarSale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data.Services
{
    public class CarsService : EntityBaseRepository<Cars>, ICarsService
    {
        private readonly AppDbContext _context;
        public CarsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCarAsync(NewCarVM data)
        {
            var newMovie = new Cars()
            {
                Name = data.Name,
                Model = data.Model,
                Year = data.Year,
                Color = data.Color,
                Mileage = data.Mileage,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CarCategory = data.CarCategory,
            };
            await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();

        }

        public async Task<Cars> GetCarByIdAsync(int id)
        {
            var carDetails = await _context.Cars
                //.Include(p => p.Make)
                .FirstOrDefaultAsync(n => n.Id == id);

            return carDetails;
        }

        public async Task<NewCarDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewCarDropdownsVM()
            {
                Models = await _context.Models.OrderBy(n => n.FullName).ToListAsync(),
                Makes = await _context.Makes.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateCarAsync(NewCarVM data)
        {
            var dbCar = await _context.Cars.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbCar != null)
            {
                dbCar.Name = data.Name;
                dbCar.Model = data.Model;
                dbCar.Year = data.Year;
                dbCar.Color = data.Color;
                dbCar.Mileage = data.Mileage;
                dbCar.Description = data.Description;
                dbCar.Price = data.Price;
                dbCar.ImageURL = data.ImageURL;
                dbCar.CarCategory = data.CarCategory;
                await _context.SaveChangesAsync();
            }

        }
    }
}
