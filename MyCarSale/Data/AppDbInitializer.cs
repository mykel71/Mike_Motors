using MyCarSale.Data.Static;
using MyCarSale.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarSale.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                
                //Models
                if (!context.Models.Any())
                {
                    context.Models.AddRange(new List<Model>()
                    {
                        new Model()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""

                        },
                        new Model()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Model()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Model()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Model()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        }
                    });
                    context.SaveChanges();
                }
                //Make
                if (!context.Makes.Any())
                {
                    context.Makes.AddRange(new List<Make>()
                    {
                        new Make()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""

                        },
                        new Make()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Make()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Make()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        },
                        new Make()
                        {
                            FullName = "",
                            Bio = "",
                            ProfilePictureURL = ""
                        }
                    });
                    context.SaveChanges();
                }
                //Cars
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Cars>()
                    {
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        },
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        },
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        },
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        },
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        },
                        new Cars()
                        {
                            Name = "",
                            Model = "",
                            Year = 2021,
                            Color = "",
                            Mileage = 1000,
                            Description = "",
                            Price = 39.50,
                            ImageURL = "",
                            CarCategory = CarCategory.Sedan
                        }
                    });
                    context.SaveChanges();
                }
               
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@mycarsale.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@mycarsale.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
