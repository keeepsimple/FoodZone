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
                Price = 270000,
                InsertedAt = DateTime.Now
            };
            var food2 = new Food
            {
                Id = 2,
                Name = "Tôm Sú",
                Price = 200000,
                InsertedAt = DateTime.Now
            };
            var food3 = new Food
            {
                Id = 3,
                Name = "Ngọc kê gà",
                Price = 50000,
                InsertedAt = DateTime.Now
            };
            var food4 = new Food
            {
                Id = 4,
                Name = "Vịt quay Đài Loan",
                Price = 280000,
                InsertedAt = DateTime.Now
            };
            var food5 = new Food
            {
                Id = 5,
                Name = "Bò ướp sốt",
                Price = 230000,
                InsertedAt = DateTime.Now
            };
            var food6 = new Food
            {
                Id = 6,
                Name = "Nước cam nguyên chất",
                Price = 35000,
                InsertedAt = DateTime.Now
            };
            var food7 = new Food
            {
                Id = 7,
                Name = "Mojito Beer",
                Price = 45000,
                InsertedAt = DateTime.Now
            };
            var food8 = new Food
            {
                Id = 8,
                Name = "Rượu rơm vàng mơ rừng",
                Price = 300000,
                InsertedAt = DateTime.Now
            };
            var food9 = new Food
            {
                Id = 9,
                Name = "Vodka Alligator",
                Price = 350000,
                InsertedAt = DateTime.Now
            };
            var food10 = new Food
            {
                Id = 10,
                Name = "Lẩu cà chua",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food11 = new Food
            {
                Id = 11,
                Name = "Lẩu Thái",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food12 = new Food
            {
                Id = 12,
                Name = "Lẩu Đài Bắc",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food13 = new Food
            {
                Id = 13,
                Name = "Ba chỉ bò Mỹ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food14 = new Food
            {
                Id = 14,
                Name = "Bắp heo Mỹ cuộn",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food15 = new Food
            {
                Id = 15,
                Name = "Chân gà rút xương",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food16 = new Food
            {
                Id = 16,
                Name = "Bạch tuộc baby",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food17 = new Food
            {
                Id = 17,
                Name = "Sủi cảo kim ngân",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food18 = new Food
            {
                Id = 18,
                Name = "Thịt bò Kobe",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food19 = new Food
            {
                Id = 19,
                Name = "Thịt nạc dăm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food20 = new Food
            {
                Id = 20,
                Name = "Thịt bò bông tuyết",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food21 = new Food
            {
                Id = 21,
                Name = "Ba chỉ lợn",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food22 = new Food
            {
                Id = 22,
                Name = "Thịt đùi bò Úc",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food23 = new Food
            {
                Id = 23,
                Name = "Hải sản thập cẩm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food24 = new Food
            {
                Id = 24,
                Name = "Bạch Tuộc",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food25 = new Food
            {
                Id = 25,
                Name = "Mực ống",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food26 = new Food
            {
                Id = 26,
                Name = "Mực sữa",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food27 = new Food
            {
                Id = 27,
                Name = " ốc móng tay ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food28 = new Food
            {
                Id = 28,
                Name = "Sò dương",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food29 = new Food
            {
                Id = 29,
                Name = "ốc tỏi",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food30 = new Food
            {
                Id = 30,
                Name = "Hàu",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food31 = new Food
            {
                Id = 31,
                Name = "Sò điệp",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food32 = new Food
            {
                Id = 32,
                Name = "Cua biển",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food33 = new Food
            {
                Id = 33,
                Name = "ếch",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food34 = new Food
            {
                Id = 34,
                Name = "Cá tầm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food35 = new Food
            {
                Id = 35,
                Name = "Rau thìa",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food36 = new Food
            {
                Id = 36,
                Name = "Rau muống",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food37 = new Food
            {
                Id = 37,
                Name = "Rau cải thảo",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food38 = new Food
            {
                Id = 38,
                Name = "Rau Salad",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food39 = new Food
            {
                Id = 39,
                Name = "Bó xôi",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food40 = new Food
            {
                Id = 40,
                Name = "Nấm kim châm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food41 = new Food
            {
                Id = 41,
                Name = "Nấm đùi gà",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food42 = new Food
            {
                Id = 42,
                Name = "Nấm bào ngư",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food43 = new Food
            {
                Id = 43,
                Name = "Mộc Nhĩ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food44 = new Food
            {
                Id = 44,
                Name = "Khoai tây",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food45 = new Food
            {
                Id = 45,
                Name = "Củ cải trắng",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food46 = new Food
            {
                Id = 46,
                Name = "Bí đỏ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food47 = new Food
            {
                Id = 47,
                Name = "Bí đao",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food48 = new Food
            {
                Id = 48,
                Name = "Bắp",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food49 = new Food
            {
                Id = 49,
                Name = "Khoai lang",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food50 = new Food
            {
                Id = 50,
                Name = "Khoai môn",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food51 = new Food
            {
                Id = 51,
                Name = "Cá viên",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food52 = new Food
            {
                Id = 52,
                Name = "Tôm viên phô mai",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food53 = new Food
            {
                Id = 53,
                Name = "Sò điệp băm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food54 = new Food
            {
                Id = 54,
                Name = "Viên rau củ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food55 = new Food
            {
                Id = 55,
                Name = "Xúc xích",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food56 = new Food
            {
                Id = 56,
                Name = "Lạp xưởng",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food57 = new Food
            {
                Id = 57,
                Name = "Viên bò phô mai",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food58 = new Food
            {
                Id = 58,
                Name = "Đậu Phụ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food59 = new Food
            {
                Id = 59,
                Name = "Giá đỗ",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food60 = new Food
            {
                Id = 60,
                Name = "Đậu phụ chiên",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food61 = new Food
            {
                Id = 61,
                Name = "Thịt bò nướng",
                Price = 250000,
                InsertedAt = DateTime.Now
            };
            var food62 = new Food
            {
                Id = 62,
                Name = "Bò lúc lắc",
                Price = 300000,
                InsertedAt = DateTime.Now
            };
            var food63 = new Food
            {
                Id = 63,
                Name = "Bao tử bò",
                Price = 200000,
                InsertedAt = DateTime.Now
            };
            var food64 = new Food
            {
                Id = 64,
                Name = "Tôm Sú Nướng",
                Price = 350000,
                InsertedAt = DateTime.Now
            };
            var food65 = new Food
            {
                Id = 65,
                Name = "Cá Ba Sa",
                Price = 400000,
                InsertedAt = DateTime.Now
            };
            var food66 = new Food
            {
                Id = 66,
                Name = "Cá Thu",
                Price = 200000,
                InsertedAt = DateTime.Now
            };
            var food67 = new Food
            {
                Id = 67,
                Name = "Múa Mì",
                Price = 500000,
                InsertedAt = DateTime.Now
            };
            var food68 = new Food
            {
                Id = 68,
                Name = "Cánh Gà",
                Price = 200000,
                InsertedAt = DateTime.Now
            };
            var food69 = new Food
            {
                Id = 69,
                Name = "Gà bó xôi",
                Price = 300000,
                InsertedAt = DateTime.Now
            };
            var food70 = new Food
            {
                Id = 70,
                Name = "Nầm Nướng",
                Price = 200000,
                InsertedAt = DateTime.Now
            };
            var food71 = new Food
            {
                Id = 71,
                Name = "Cơm Trắng",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food72 = new Food
            {
                Id = 72,
                Name = "Miến Trộn",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food73 = new Food
            {
                Id = 73,
                Name = "Mì ăn liền",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food74 = new Food
            {
                Id = 74,
                Name = "Phở chua cay",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food75 = new Food
            {
                Id = 75,
                Name = "Nem tôm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food76 = new Food
            {
                Id = 76,
                Name = "Thịt trưng mắm tép",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food77 = new Food
            {
                Id = 77,
                Name = "Lẩu thái cốt dừa",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food78 = new Food
            {
                Id = 78,
                Name = "Lẩu thái chua cay",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food79 = new Food
            {
                Id = 79,
                Name = "Lẩu thái tứ xuyên",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food80 = new Food
            {
                Id = 80,
                Name = "Lẩu thái tomyum",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food81 = new Food
            {
                Id = 81,
                Name = "Lẩu thập cẩm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food82 = new Food
            {
                Id = 82,
                Name = "Lẩu Nấm",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food83 = new Food
            {
                Id = 83,
                Name = "Lẩu Dầu Cay",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food84 = new Food
            {
                Id = 84,
                Name = "Lẩu Hải Sản",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food85 = new Food
            {
                Id = 85,
                Name = "Lẩu Cua",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food86 = new Food
            {
                Id = 86,
                Name = "Coca",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food87 = new Food
            {
                Id = 87,
                Name = "Pepsi",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food88 = new Food
            {
                Id = 88,
                Name = "7Up",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var food89 = new Food
            {
                Id = 89,
                Name = "SoJu",
                Price = 0,
                InsertedAt = DateTime.Now
            };
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Thực đơn đặc biệt",
                    Image = "dac_biet.JPG",
                    Foods = new List<Food>{food1, food2, food3, food4, food5,food61,food62,food63,food64,food65,food66,food67,food68,food69,food70,food18},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Nước lẩu",
                    Image = "nuoc lau.jpg",
                    Foods = new List<Food>{food10,food11,food12,food77,food78,food79,food80,food81,food82,food83,food84,food85},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=3,
                    Name="Bò",
                    Image = "thit_bo_bong_tuyet.jpg",
                    Foods = new List<Food>{food13,food20,food22},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=4,
                    Name="Heo",
                    Image = "ba_chi_lon.jpg",
                    Foods = new List<Food>{food14,food19,food21},
                    InsertedAt = DateTime.Now
                },new Category
                {
                    Id=5,
                    Name="Gà",
                    Image = "ga.JPG",
                    Foods = new List<Food>{food15},
                    InsertedAt = DateTime.Now
                },new Category
                {
                    Id=6,
                    Name="Hải sản",
                    Image = "hai_san.JPG",
                    Foods = new List<Food>{food16,food23,food24,food25,food26,food27,food28,food29,food30,food31,food32,food33,food34},
                    InsertedAt = DateTime.Now
                }
                ,new Category
                {
                    Id=7,
                    Name="Viên thả lẩu",
                    Image = "vien.JPG",
                    Foods = new List<Food>{food17,food40,food41,food42,food43,food44,food45,food46,food47,food48,food49,food50,food51,food52,food53,food54,food55,food56,food57},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=8,
                    Name="Đồ uống",
                    Image = "do_uong.JPG",
                    Foods = new List<Food>{food6, food7, food8,food9,food86,food87,food88,food89},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=9,
                    Name="Rau và đậu",
                    Image = "salad.jpg",
                    Foods = new List<Food>{food35,food36,food37,food38,food39,food58,food59,food60},
                    InsertedAt = DateTime.Now
                },
                new Category
                {
                    Id=10,
                    Name="Đồ ăn kèm",
                    Image = "an_them.JPG",
                    Foods = new List<Food>{food71,food72,food73,food74,food75,food76},
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
                },new MenuCategory
                {
                    CategoryId=9,
                    MenuId= 1,
                    InsertedAt = DateTime.Now
                },
                new MenuCategory
                {
                    CategoryId=10,
                    MenuId= 1,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=9,
                    MenuId= 2,
                    InsertedAt = DateTime.Now
                },
                new MenuCategory
                {
                    CategoryId=10,
                    MenuId= 2,
                    InsertedAt = DateTime.Now
                },new MenuCategory
                {
                    CategoryId=9,
                    MenuId= 3,
                    InsertedAt = DateTime.Now
                },
                new MenuCategory
                {
                    CategoryId=10,
                    MenuId= 3,
                    InsertedAt = DateTime.Now
                }
            };

            context.MenuCategories.AddRange(menuCategories);

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