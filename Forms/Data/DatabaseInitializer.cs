using System;
using System.IO;
using System.Linq;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_Parts_Store.Data
{
    public static class DatabaseInitializer
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void InitializeDatabase()
        {
            try
            {
                Console.WriteLine("Ініціалізація бази даних SQLite...");

                var connectionString = GetConnectionString();
                Console.WriteLine($"Підключення: {connectionString}");

                var options = new DbContextOptionsBuilder<Computer_Parts_StoreContext>()
                    .UseSqlite(connectionString)
                    .Options;

                using var context = new Computer_Parts_StoreContext(options);

                Console.WriteLine("Створення бази даних...");
                context.Database.EnsureCreated();

                Console.WriteLine("Перевірка наявності даних...");

                if (!context.Products.Any())
                {
                    Console.WriteLine("Додавання тестових даних...");
                    SeedTestData(context);
                    Console.WriteLine("Тестові дані успішно додано!");
                }
                else
                {
                    Console.WriteLine("Дані вже існують в базі");
                    Console.WriteLine($"Знайдено {context.Products.Count()} товарів");
                }

                DisplayCatalogInfo(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Помилка: {exception.Message}");
                if (exception.InnerException != null)
                {
                    Console.WriteLine($"Внутрішня помилка: {exception.InnerException.Message}");
                }
            }
        }

        private static void SeedTestData(Computer_Parts_StoreContext context)
        {
            try
            {
                if (!context.Categories.Any())
                {
                    Console.WriteLine("Створення категорій...");
                    var categories = new[]
                    {
                        new Category { Name = "Процесори (CPU)" },
                        new Category { Name = "Відеокарти (GPU)" },
                        new Category { Name = "Материнські плати" },
                        new Category { Name = "Оперативна пам'ять (RAM)" },
                        new Category { Name = "SSD накопичувачі" },
                        new Category { Name = "HDD накопичувачі" },
                        new Category { Name = "Блоки живлення (PSU)" },
                        new Category { Name = "Корпуси" },
                        new Category { Name = "Повітряне охолодження" },
                        new Category { Name = "Рідинне охолодження" },
                        new Category { Name = "Кулери" },
                        new Category { Name = "Монітори" },
                        new Category { Name = "Клавіатури" },
                        new Category { Name = "Миші" }
                    };

                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                    Console.WriteLine("Категорії додано успішно");
                }

                if (!context.Products.Any())
                {
                    var processorCategory = context.Categories.First(category => category.Name.Contains("Процесори"));
                    var videoCardCategory = context.Categories.First(category => category.Name.Contains("Відеокарти"));
                    var motherboardCategory = context.Categories.First(category => category.Name.Contains("Материнські"));
                    var memoryCategory = context.Categories.First(category => category.Name.Contains("Оперативна"));
                    var solidStateDriveCategory = context.Categories.First(category => category.Name.Contains("SSD"));
                    var hardDriveCategory = context.Categories.First(category => category.Name.Contains("HDD"));
                    var powerSupplyCategory = context.Categories.First(category => category.Name.Contains("Блоки живлення"));
                    var caseCategory = context.Categories.First(category => category.Name.Contains("Корпуси"));
                    var airCoolingCategory = context.Categories.First(category => category.Name.Contains("Повітряне"));
                    var liquidCoolingCategory = context.Categories.First(category => category.Name.Contains("Рідинне"));
                    var fansCategory = context.Categories.First(category => category.Name.Contains("Кулери"));
                    var monitorCategory = context.Categories.First(category => category.Name.Contains("Монітори"));
                    var keyboardCategory = context.Categories.First(category => category.Name.Contains("Клавіатури"));
                    var mouseCategory = context.Categories.First(category => category.Name.Contains("Миші"));

                    AddProcessorProducts(context, processorCategory.Id);
                    AddVideoCardProducts(context, videoCardCategory.Id);
                    AddMotherboardProducts(context, motherboardCategory.Id);
                    AddMemoryProducts(context, memoryCategory.Id);
                    AddSolidStateDriveProducts(context, solidStateDriveCategory.Id);
                    AddHardDriveProducts(context, hardDriveCategory.Id);
                    AddPowerSupplyProducts(context, powerSupplyCategory.Id);
                    AddCaseProducts(context, caseCategory.Id);
                    AddAirCoolingProducts(context, airCoolingCategory.Id);
                    AddLiquidCoolingProducts(context, liquidCoolingCategory.Id);
                    AddFanProducts(context, fansCategory.Id);
                    AddMonitorProducts(context, monitorCategory.Id);
                    AddKeyboardProducts(context, keyboardCategory.Id);
                    AddMouseProducts(context, mouseCategory.Id);

                    Console.WriteLine("Всі товари успішно додано!");
                }

                if (!context.PrebuiltComputers.Any())
                {
                    Console.WriteLine("Створення готових збірок ПК...");
                    AddPrebuiltComputers(context);
                    Console.WriteLine("Готові збірки ПК успішно додано!");
                }

                Console.WriteLine("Замовлення, клієнти та кошик залишено порожніми для заповнення користувачем.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Помилка при додаванні даних: {exception.Message}");
                throw;
            }
        }

        private static void AddPrebuiltComputers(Computer_Parts_StoreContext context)
        {
            var ryzenProcessor = context.Products.First(product => product.Article == "RYZEN5-5600X");
            var rtxVideoCard = context.Products.First(product => product.Article == "RTX4060-8G");
            var asusMotherboard = context.Products.First(product => product.Article == "B550-TUF");
            var kingstonMemory = context.Products.First(product => product.Article == "KF416-16");
            var samsungSolidStateDrive = context.Products.First(product => product.Article == "970EVO-1TB");
            var bequietPowerSupply = context.Products.First(product => product.Article == "PP11-600W");
            var nzxtCase = context.Products.First(product => product.Article == "NZXT-H510");
            var deepcoolCooler = context.Products.First(product => product.Article == "AK620");

            var intelProcessor = context.Products.First(product => product.Article == "I5-12400F");
            var amdVideoCard = context.Products.First(product => product.Article == "RX7600-8G");
            var gigabyteMotherboard = context.Products.First(product => product.Article == "B760-GIGA");
            var corsairMemory = context.Products.First(product => product.Article == "CMG32-D5");
            var westernDigitalSolidStateDrive = context.Products.First(product => product.Article == "SN850X-2T");
            var corsairPowerSupply = context.Products.First(product => product.Article == "CP-9020180");
            var fractalCase = context.Products.First(product => product.Article == "FD-C-MES2-01");

            var prebuiltComputers = new[]
            {
                new PrebuiltComputer
                {
                    Name = "Gaming PC AMD Ryzen 5 + RTX 4060",
                    Description = "Ігрова збірка для геймінгу 1080p/1440p",
                    Products = new[] { ryzenProcessor, rtxVideoCard, asusMotherboard, kingstonMemory, samsungSolidStateDrive, bequietPowerSupply, nzxtCase, deepcoolCooler }
                },
                new PrebuiltComputer
                {
                    Name = "Gaming PC Intel Core i5 + RX 7600",
                    Description = "Балансна ігрова збірка для есіммерів",
                    Products = new[] { intelProcessor, amdVideoCard, gigabyteMotherboard, corsairMemory, westernDigitalSolidStateDrive, corsairPowerSupply, fractalCase }
                }
            };

            foreach (var computer in prebuiltComputers)
            {
                if (!context.PrebuiltComputers.Any(prebuiltComputer => prebuiltComputer.Name == computer.Name))
                {
                    context.PrebuiltComputers.Add(computer);
                }
            }
            context.SaveChanges();
        }

        private static void DisplayCatalogInfo(Computer_Parts_StoreContext context)
        {
            Console.WriteLine("\n=== КАТАЛОГ ТОВАРІВ ===");
            Console.WriteLine($"Категорій: {context.Categories.Count()}");
            Console.WriteLine($"Товарів: {context.Products.Count()}");
            Console.WriteLine($"Готових збірок ПК: {context.PrebuiltComputers.Count()}");

            Console.WriteLine("\n=== КАТЕГОРІЇ ТА КІЛЬКІСТЬ ТОВАРІВ ===");
            foreach (var category in context.Categories.OrderBy(category => category.Name))
            {
                var productCount = context.Products.Count(product => product.CategoryId == category.Id);
                Console.WriteLine($"- {category.Name}: {productCount} шт");
            }

            Console.WriteLine("\n=== ГОТОВІ ЗБІРКИ ПК ===");
            foreach (var prebuiltComputer in context.PrebuiltComputers)
            {
                Console.WriteLine($"- {prebuiltComputer.Name}: {prebuiltComputer.TotalPrice} грн");
            }

            Console.WriteLine($"\n=== СТАТИСТИКА КОРИСТУВАЧА ===");
            Console.WriteLine($"Клієнтів: {context.Customers.Count()} (порожньо - додасть користувач)");
            Console.WriteLine($"Замовлень: {context.Orders.Count()} (порожньо - додасть користувач)");
        }

        private static void AddProcessorProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Процесори");

            var products = new[]
            {
                new Product { Name = "AMD Ryzen 5 5600X", Article = "RYZEN5-5600X", Price = 7500m, Description = "6 ядер, 12 потоків, 3.7-4.6 GHz, AM4", StockQuantity = 15, Manufacturer = "AMD", Model = "Ryzen 5 5600X", Specification = "6 cores, 12 threads", Color = "Silver", Dimensions = "40x40mm", Weight = 0.1m, WarrantyMonths = 36, CategoryId = categoryId },
                new Product { Name = "Intel Core i5-12400F", Article = "I5-12400F", Price = 6800m, Description = "6 ядер, 12 потоків, 2.5-4.4 GHz, LGA1700", StockQuantity = 20, Manufacturer = "Intel", Model = "Core i5-12400F", Specification = "6 cores, 12 threads", Color = "Silver", Dimensions = "45x45mm", Weight = 0.12m, WarrantyMonths = 36, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddVideoCardProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Відеокарти");

            var products = new[]
            {
                new Product { Name = "NVIDIA GeForce RTX 4060", Article = "RTX4060-8G", Price = 14500m, Description = "8GB GDDR6, 3072 ядер, PCIe 4.0", StockQuantity = 8, Manufacturer = "NVIDIA", Model = "RTX 4060", Specification = "8GB GDDR6", Color = "Black", Dimensions = "240x110mm", Weight = 0.8m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "AMD Radeon RX 7600", Article = "RX7600-8G", Price = 13200m, Description = "8GB GDDR6, 2048 ядер, PCIe 4.0", StockQuantity = 6, Manufacturer = "AMD", Model = "Radeon RX 7600", Specification = "8GB GDDR6", Color = "Black", Dimensions = "230x100mm", Weight = 0.7m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddMotherboardProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Материнські плати");

            var products = new[]
            {
                new Product { Name = "ASUS TUF GAMING B550-PLUS", Article = "B550-TUF", Price = 5200m, Description = "AMD B550, Socket AM4, ATX", StockQuantity = 12, Manufacturer = "ASUS", Model = "TUF GAMING B550-PLUS", Specification = "AMD B550", Color = "Black", Dimensions = "305x244mm", Weight = 1.2m, WarrantyMonths = 36, CategoryId = categoryId },
                new Product { Name = "Gigabyte B760 GAMING X", Article = "B760-GIGA", Price = 4800m, Description = "Intel B760, LGA1700, ATX", StockQuantity = 10, Manufacturer = "Gigabyte", Model = "B760 GAMING X", Specification = "Intel B760", Color = "Black", Dimensions = "305x244mm", Weight = 1.1m, WarrantyMonths = 36, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddMemoryProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Оперативна пам'ять");

            var products = new[]
            {
                new Product { Name = "Kingston FURY Beast 16GB DDR4", Article = "KF416-16", Price = 2800m, Description = "DDR4 3200MHz, CL16, 2x8GB", StockQuantity = 25, Manufacturer = "Kingston", Model = "FURY Beast", Specification = "16GB DDR4", Color = "Black", Dimensions = "133x30mm", Weight = 0.05m, WarrantyMonths = 36, CategoryId = categoryId },
                new Product { Name = "Corsair Vengeance RGB 32GB DDR5", Article = "CMG32-D5", Price = 4200m, Description = "DDR5 5600MHz, CL36, 2x16GB", StockQuantity = 15, Manufacturer = "Corsair", Model = "Vengeance RGB", Specification = "32GB DDR5", Color = "Black", Dimensions = "133x30mm", Weight = 0.06m, WarrantyMonths = 36, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddSolidStateDriveProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: SSD накопичувачі");

            var products = new[]
            {
                new Product { Name = "Samsung 970 EVO Plus 1TB", Article = "970EVO-1TB", Price = 3800m, Description = "NVMe PCIe 3.0, 3500/3300 MB/s", StockQuantity = 18, Manufacturer = "Samsung", Model = "970 EVO Plus", Specification = "1TB NVMe", Color = "Black", Dimensions = "80x22mm", Weight = 0.01m, WarrantyMonths = 60, CategoryId = categoryId },
                new Product { Name = "WD Black SN850X 2TB", Article = "SN850X-2T", Price = 6200m, Description = "NVMe PCIe 4.0, 7300/6600 MB/s", StockQuantity = 12, Manufacturer = "Western Digital", Model = "Black SN850X", Specification = "2TB NVMe", Color = "Black", Dimensions = "80x22mm", Weight = 0.01m, WarrantyMonths = 60, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddHardDriveProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: HDD накопичувачі");

            var products = new[]
            {
                new Product { Name = "Seagate BarraCuda 2TB", Article = "ST2000DM", Price = 2200m, Description = "HDD 7200RPM, SATA 6Gb/s", StockQuantity = 10, Manufacturer = "Seagate", Model = "BarraCuda", Specification = "2TB HDD", Color = "Silver", Dimensions = "147x102mm", Weight = 0.5m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "WD Blue 4TB", Article = "WD40EZAZ", Price = 3200m, Description = "HDD 5400RPM, SATA 6Gb/s", StockQuantity = 8, Manufacturer = "Western Digital", Model = "Blue", Specification = "4TB HDD", Color = "Blue", Dimensions = "147x102mm", Weight = 0.6m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddPowerSupplyProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Блоки живлення");

            var products = new[]
            {
                new Product { Name = "be quiet! Pure Power 11 600W", Article = "PP11-600W", Price = 3200m, Description = "600W, 80+ Gold, модульний", StockQuantity = 14, Manufacturer = "be quiet!", Model = "Pure Power 11", Specification = "600W Gold", Color = "Black", Dimensions = "140x150mm", Weight = 2.1m, WarrantyMonths = 60, CategoryId = categoryId },
                new Product { Name = "Corsair RM850x 850W", Article = "CP-9020180", Price = 4500m, Description = "850W, 80+ Gold, повністю модульний", StockQuantity = 9, Manufacturer = "Corsair", Model = "RM850x", Specification = "850W Gold", Color = "Black", Dimensions = "150x160mm", Weight = 2.3m, WarrantyMonths = 60, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddCaseProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Корпуси");

            var products = new[]
            {
                new Product { Name = "NZXT H510", Article = "NZXT-H510", Price = 4100m, Description = "Mid-Tower, ATX, tempered glass", StockQuantity = 7, Manufacturer = "NZXT", Model = "H510", Specification = "Mid-Tower", Color = "Black", Dimensions = "460x210mm", Weight = 6.7m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "Fractal Design Meshify 2", Article = "FD-C-MES2-01", Price = 5200m, Description = "Mid-Tower, ATX, mesh front panel", StockQuantity = 5, Manufacturer = "Fractal Design", Model = "Meshify 2", Specification = "Mid-Tower", Color = "Black", Dimensions = "475x215mm", Weight = 7.2m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddAirCoolingProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Повітряне охолодження");

            var products = new[]
            {
                new Product { Name = "DeepCool AK620", Article = "AK620", Price = 1800m, Description = "CPU Cooler, 260W TDP, dual tower", StockQuantity = 9, Manufacturer = "DeepCool", Model = "AK620", Specification = "Dual Tower", Color = "Black", Dimensions = "129x138mm", Weight = 1.2m, WarrantyMonths = 36, CategoryId = categoryId },
                new Product { Name = "Noctua NH-D15", Article = "NH-D15", Price = 3200m, Description = "CPU Cooler, 220W TDP, dual tower", StockQuantity = 6, Manufacturer = "Noctua", Model = "NH-D15", Specification = "Dual Tower", Color = "Brown", Dimensions = "165x150mm", Weight = 1.3m, WarrantyMonths = 72, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddLiquidCoolingProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Рідинне охолодження");

            var products = new[]
            {
                new Product { Name = "Corsair iCUE H150i Elite", Article = "CW-9060056-WW", Price = 5200m, Description = "360mm AIO, RGB, LCD display", StockQuantity = 8, Manufacturer = "Corsair", Model = "iCUE H150i Elite", Specification = "360mm AIO", Color = "Black", Dimensions = "397x120mm", Weight = 1.5m, WarrantyMonths = 60, CategoryId = categoryId },
                new Product { Name = "NZXT Kraken X73", Article = "RL-KRX73-01", Price = 4800m, Description = "360mm AIO, RGB, CAM software", StockQuantity = 7, Manufacturer = "NZXT", Model = "Kraken X73", Specification = "360mm AIO", Color = "Black", Dimensions = "397x120mm", Weight = 1.4m, WarrantyMonths = 60, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddFanProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Кулери");

            var products = new[]
            {
                new Product { Name = "Noctua NF-A12x25", Article = "NF-A12x25", Price = 800m, Description = "120mm fan, 2000 RPM, PWM", StockQuantity = 20, Manufacturer = "Noctua", Model = "NF-A12x25", Specification = "120mm PWM", Color = "Brown", Dimensions = "120x120mm", Weight = 0.2m, WarrantyMonths = 72, CategoryId = categoryId },
                new Product { Name = "Corsair iCUE SP120 RGB Elite", Article = "CO-9050105-WW", Price = 600m, Description = "120mm fan, RGB, PWM", StockQuantity = 25, Manufacturer = "Corsair", Model = "SP120 RGB Elite", Specification = "120mm RGB", Color = "Black", Dimensions = "120x120mm", Weight = 0.18m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddMonitorProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Монітори");

            var products = new[]
            {
                new Product { Name = "Samsung Odyssey G5 27\"", Article = "ODG5-27", Price = 8900m, Description = "27\", 1440p, 144Hz, 1ms", StockQuantity = 5, Manufacturer = "Samsung", Model = "Odyssey G5", Specification = "27\" 1440p", Color = "Black", Dimensions = "613x461mm", Weight = 5.5m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "LG UltraGear 24GN600-B", Article = "24GN600-B", Price = 6500m, Description = "24\", 1080p, 144Hz, IPS", StockQuantity = 8, Manufacturer = "LG", Model = "UltraGear 24GN600-B", Specification = "24\" 1080p", Color = "Black", Dimensions = "540x420mm", Weight = 3.8m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddKeyboardProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Клавіатури");

            var products = new[]
            {
                new Product { Name = "Razer BlackWidow V3", Article = "RZ03-0354", Price = 3200m, Description = "Mechanical, Green switches, RGB", StockQuantity = 12, Manufacturer = "Razer", Model = "BlackWidow V3", Specification = "Mechanical", Color = "Black", Dimensions = "440x150mm", Weight = 1.2m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "Logitech G Pro X", Article = "920-0092", Price = 3800m, Description = "Mechanical, GX Blue switches, RGB", StockQuantity = 15, Manufacturer = "Logitech", Model = "G Pro X", Specification = "Mechanical", Color = "Black", Dimensions = "435x140mm", Weight = 1.1m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        private static void AddMouseProducts(Computer_Parts_StoreContext context, int categoryId)
        {
            Console.WriteLine("Додаємо товари для: Миші");

            var products = new[]
            {
                new Product { Name = "Logitech G Pro X Superlight", Article = "910-0056", Price = 3800m, Description = "Wireless, 25K DPI, 63g", StockQuantity = 15, Manufacturer = "Logitech", Model = "G Pro X Superlight", Specification = "Wireless", Color = "White", Dimensions = "125x63mm", Weight = 0.063m, WarrantyMonths = 24, CategoryId = categoryId },
                new Product { Name = "Razer DeathAdder V2", Article = "RZ01-0321", Price = 2500m, Description = "Wired, 20K DPI, 82g", StockQuantity = 20, Manufacturer = "Razer", Model = "DeathAdder V2", Specification = "Wired", Color = "Black", Dimensions = "127x61mm", Weight = 0.082m, WarrantyMonths = 24, CategoryId = categoryId }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(existingProduct => existingProduct.Article == product.Article))
                {
                    context.Products.Add(product);
                }
            }
            context.SaveChanges();
        }

        public static void DisplayDatabaseInfo()
        {
            try
            {
                var connectionString = GetConnectionString();
                var options = new DbContextOptionsBuilder<Computer_Parts_StoreContext>()
                    .UseSqlite(connectionString)
                    .Options;

                using var context = new Computer_Parts_StoreContext(options);

                Console.WriteLine("\n=== ІНФОРМАЦІЯ ПРО БАЗУ SQLite ===");
                Console.WriteLine($"Файл бази: {Path.GetFullPath("ComputerPartsStore.db")}");

                DisplayCatalogInfo(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Помилка при отриманні інформації: {exception.Message}");
            }
        }
    }
}