using FoodZone.Models.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FoodZone.Models.Security;

namespace FoodZone.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<FoodZoneContext>
    {
        protected override void Seed(FoodZoneContext context)
        {
            InitializeIdentity(context);

            var menu = new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Name = "Buffet 199k",
                    Description = "Buffet 199k",
                    Price = 199000,
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 2,
                    Name = "Buffet 299k",
                    Description = "Buffet 299k",
                    Price = 299000,
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 3,
                    Name = "Buffet 399k",
                    Description = "Buffet 399k",
                    Price=399000,
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 4,
                    Name = "Thực Đơn Đặc Biệt",
                    Description = "Thực Đơn Đặc Biệt",
                    Price=0,
                    InsertedAt = DateTime.Now
                }
            };

            context.Menus.AddRange(menu);

            var food1 = new Food
            {
                Id = 1,
                Name = "Lõi vai Wagyu",
                Description = "Lõi vai Wagyu",
                Price = 269000,
                InsertedAt = DateTime.Now
            };
            var food2 = new Food
            {
                Id = 2,
                Name = "Tôm Sú",
                Description = "Tôm Sú",
                Price = 199000,
                InsertedAt = DateTime.Now
            };
            var food3 = new Food
            {
                Id = 3,
                Name = "Ngọc kê gà",
                Description = "Ngọc kê gà",
                Price = 50000,
                InsertedAt = DateTime.Now
            };
            var food4 = new Food
            {
                Id = 4,
                Name = "Vịt quay Đài Loan",
                Description = "Vịt quay Đài Loan",
                Price = 179000,
                InsertedAt = DateTime.Now
            };
            var food5 = new Food
            {
                Id = 5,
                Name = "Bò ướp sốt",
                Description = "Bò ướp sốt đặc biệt",
                Price = 199000,
                InsertedAt = DateTime.Now
            };
            var food6 = new Food
            {
                Id = 6,
                Name = "Nước cam nguyên chất",
                Description = "Nước cam nguyên chất",
                Price = 35000,
                InsertedAt = DateTime.Now
            };
            var food7 = new Food
            {
                Id = 7,
                Name = "Mojito Beer",
                Description = "Mojito Beer",
                Price = 45000,
                InsertedAt = DateTime.Now
            };
            var food8 = new Food
            {
                Id = 8,
                Name = "Rượu rơm vàng mơ rừng",
                Description = "Rượu rơm vàng mơ rừng 300ML",
                Price = 300000,
                InsertedAt = DateTime.Now
            };
            var food9 = new Food
            {
                Id = 9,
                Name = "Vodka Alligator",
                Description = "Vodka Alligator xanh 500ML",
                Price = 350000,
                InsertedAt = DateTime.Now
            };
            var food10 = new Food
            {
                Id = 10,
                Name = "Lẩu cà chua",
                Description = "Lẩu cà chua",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food11 = new Food
            {
                Id = 11,
                Name = "Lẩu Thái",
                Description = "Lẩu Thái",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food12 = new Food
            {
                Id = 12,
                Name = "Lẩu Đài Bắc",
                Description = "Lẩu Đài Bắc",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food13 = new Food
            {
                Id = 13,
                Name = "Ba chỉ bò Mỹ",
                Description = "Ba chỉ bò Mỹ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food14 = new Food
            {
                Id = 14,
                Name = "Bắp heo Mỹ cuộn",
                Description = "Bắp heo Mỹ cuộn",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food15 = new Food
            {
                Id = 15,
                Name = "Chân gà rút xương",
                Description = "Chân gà rút xương",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food16 = new Food
            {
                Id = 16,
                Name = "Bạch tuộc baby",
                Description = "Bạch tuộc baby",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food17 = new Food
            {
                Id = 17,
                Name = "Sủi cảo kim ngân",
                Description = "Sủi cảo kim ngân",
                Price = 0,
                InsertedAt = DateTime.Now
            };

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Thực đơn đặc biệt",
                    Foods = new List<Food>{food1, food2, food3, food4, food5},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Nước lẩu",
                    Foods = new List<Food>{food10,food11,food12},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=3,
                    Name="Bò",
                    Foods = new List<Food>{food13},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=4,
                    Name="Heo",
                    Foods = new List<Food>{food14},
                    InsertedAt = DateTime.Now
                },new Category
                {
                    Id=5,
                    Name="Gà",
                    Foods = new List<Food>{food15},
                    InsertedAt = DateTime.Now
                },new Category
                {
                    Id=6,
                    Name="Hải sản",
                    Foods = new List<Food>{food16},
                    InsertedAt = DateTime.Now
                }
                ,new Category
                {
                    Id=7,
                    Name="Đồ viên và dimsum",
                    Foods = new List<Food>{food17},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=8,
                    Name="Đồ uống",
                    Foods = new List<Food>{food6, food7, food8,food9},
                    InsertedAt = DateTime.Now
                }
            };

            context.Categories.AddRange(categories);

            var menuCategories = new List<MenuCategory>
            {
                new MenuCategory
                {
                    CategoryId=1,
                    MenuId=4,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=2,
                    MenuId=1,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=2,
                    MenuId=2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=2,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=3,
                    MenuId=2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=3,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=4,
                    MenuId=1,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=4,
                    MenuId=2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=4,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=5,
                    MenuId=1,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=5,
                    MenuId=2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=5,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=6,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=7,
                    MenuId=1,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=7,
                    MenuId=2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=7,
                    MenuId=3,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=8,
                    MenuId=4,
                    InsertedAt = DateTime.Now
                },
            };

            context.MenuCategories.AddRange(menuCategories);

            var tables = new List<Table>
            {
                new Table
                {
                    Id=1,
                    Capacity = 2,
                    Floor=1,
                    InsertedAt = DateTime.Now,
                    NumberTable=1,
                    Status = 0
                },
                new Table
                {
                    Id=2,
                    Capacity = 4,
                    Floor=1,
                    InsertedAt = DateTime.Now,
                    NumberTable=2,
                    Status = 0
                },
                new Table
                {
                    Id=3,
                    Capacity = 6,
                    Floor=1,
                    InsertedAt = DateTime.Now,
                    NumberTable=3,
                    Status = 0
                },
                new Table
                {
                    Id=4,
                    Capacity = 8,
                    Floor=1,
                    InsertedAt = DateTime.Now,
                    NumberTable=4,
                    Status = 0
                },
                new Table
                {
                    Id=5,
                    Capacity = 8,
                    Floor=1,
                    InsertedAt = DateTime.Now,
                    NumberTable=5,
                    Status = 0
                }
            };

            context.Tables.AddRange(tables);

            context.SaveChanges();
        }

        public static void InitializeIdentity(FoodZoneContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string email = "admin@example.com";
            const string password = "admin123";
            const string roleName = "Manager";

            //Create Role Manager if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            //Create Role User if it does not exist
            var roleUser = roleManager.FindByName("User");
            if (roleUser == null)
            {
                roleUser = new IdentityRole("User");
                var roleResult = roleManager.Create(roleUser);
            }

            //Create Role Staff if it does not exist
            var roleStaff = roleManager.FindByName("Staff");
            if (roleStaff == null)
            {
                roleStaff = new IdentityRole("Staff");
                var roleResult = roleManager.Create(roleStaff);
            }

            var user = userManager.FindByName(email);
            if (user == null)
            {
                user = new User { UserName = "Manager", FullName="Manager", Email = email, Level = 0, PhoneNumber = "0985786750" };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Manager if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}