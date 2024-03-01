using ecommerce.Enums;
using ecommerce.Shared;
using static System.Net.WebRequestMethods;

namespace ecommerce.Models
{
    public static class DbSeeder
    {
        public static void DoSeeding(AppDbContext dbContext)
        {
            SeedUsers(dbContext);
            SeedProducts(dbContext);
        }

        private static void SeedUsers(AppDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = new User[]
                {
                    new User()
                    {
                        FirstName = "Carlos Enrique",
                        LastName = "Duarte Ortiz",
                        Email = "carlosduarte.1@hotmail.com",
                        Username = "cedo",
                        PasswordHash = Util.GetSha256("Universogalaxia123#"),
                        PhoneNumber = "+526622799242",
                        Birthdate = new DateTime(1995, 2, 5),
                        Country = "México",
                        Province = "Sonora",
                        City = "Hermosillo",
                        ZipCode = "83170",
                        Type = UserType.Administrator
                    },
                    new User()
                    {
                        FirstName = "Ana Maria",
                        LastName = "Duarte Ortiz",
                        Email = "ana11nov@hotmail.com",
                        Username = "maye",
                        PasswordHash = Util.GetSha256("Universogalaxia123#"),
                        PhoneNumber = "+526622005361",
                        Birthdate = new DateTime(1997, 11, 11),
                        Country = "México",
                        Province = "Sonora",
                        City = "Hermosillo",
                        ZipCode = "83170"
                    },
                    new User()
                    {
                        FirstName = "Ana Maria",
                        LastName = "Ortiz Hoyos",
                        Email = "ana.ma.oh@hotmail.com",
                        Username = "ana",
                        PasswordHash = Util.GetSha256("Universogalaxia123#"),
                        PhoneNumber = "+526621878819",
                        Birthdate = new DateTime(1965, 11, 11),
                        Country = "México",
                        Province = "Sonora",
                        City = "Hermosillo",
                        ZipCode = "83170"
                    },
                    new User()
                    {
                        FirstName = "Luis Diego",
                        LastName = "Abril Ortiz",
                        Email = "luisdao@hotmail.com",
                        Username = "luis",
                        PasswordHash = Util.GetSha256("Universogalaxia123#"),
                        PhoneNumber = "+526621038401",
                        Birthdate = new DateTime(1998, 11, 11),
                        Country = "México",
                        Province = "Sonora",
                        City = "Hermosillo",
                        ZipCode = "83170"
                    }
                };
                foreach (User user in users)
                {
                    dbContext.Users.Add(user);
                }
                dbContext.SaveChanges();
            }
        }

        private static void SeedProducts(AppDbContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                var products = new Product[]
                {
                    new Product()
                    {
                        Name = "PlayStation 5",
                        Description = "Videgames console",
                        Price = 10000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/41p8FiLGtrL.jpg"
                    },
                    new Product()
                    {
                        Name = "Nintendo Switch",
                        Description = "Videgames console",
                        Price = 5000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/71qccaRKQVL.jpg"
                    },
                    new Product()
                    {
                        Name = "iPhone X",
                        Description = "Phone device",
                        Price = 30000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/51S-6V4UOLL.jpg"
                    },
                    new Product()
                    {
                        Name = "Laptop HP",
                        Description = "Laptop personal computer",
                        Price = 15000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/419cAD-aGYL._AC_UF894,1000_QL80_.jpg"
                    },
                    new Product()
                    {
                        Name = "UPC Steren",
                        Description = "NoBreak UPC 120V",
                        Price = 4000.0m,
                        Stock = 200,
                        Imagehref = "https://lh3.googleusercontent.com/proxy/0F2d4mEcMezG6kmrSTI9XSqa-hZ2vaVu7QITI3T0lZGkrbrMrN-MOGfNLfSRtZgdPAy9LLL8x_sdsJ1ZX4-d2zvwAID9CK0"
                    },
                    new Product()
                    {
                        Name = "Laptop DELL",
                        Description = "Laptop personal computer",
                        Price = 20000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61-yln4IXjL.jpg"
                    },
                    new Product()
                    {
                        Name = "Huawei Phone",
                        Description = "Phone device",
                        Price = 3500.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61LGH5P5JHL._AC_UF894,1000_QL80_.jpg"
                    },
                    new Product()
                    {
                        Name = "Cisco Switch 24 ports",
                        Description = "Cisco Switch network device of 24 ports",
                        Price = 17000.0m,
                        Stock = 200,
                        Imagehref = "https://microless.com/cdn/products/183efcf0faa060d945876133bec8539d-hi.jpg"
                    },
                    new Product()
                    {
                        Name = "Wallet York Team",
                        Description = "Men's wallet York Team Polo Club",
                        Price = 1000.0m,
                        Stock = 200,
                        Imagehref = "https://http2.mlstatic.com/D_NQ_NP_988266-MLM49266249778_032022-O.webp"
                    },
                    new Product()
                    {
                        Name = "Resistor 120 ohms",
                        Description = "Resistor 120 ohms 1/2 watt",
                        Price = 2.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61-ZdiAbccL.jpg"
                    },
                    new Product()
                    {
                        Name = "Potentiometer 5K",
                        Description = "Variable resistor of 5K",
                        Price = 5.0m,
                        Stock = 200,
                        Imagehref = "https://ipowerelectronics.com.mx/4767-large_default/potenciometro-de-1k-ohm.jpg"
                    },
                    new Product()
                    {
                        Name = "Microphone",
                        Description = "Seteren Microphone 20DB",
                        Price = 500.0m,
                        Stock = 200,
                        Imagehref = "https://www.sterenbasics.com/cdn/shop/products/WR-802UHF_grande.jpg?v=1424730197"
                    },
                    new Product()
                    {
                        Name = "PlayStation 4",
                        Description = "Videgames console",
                        Price = 8000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/41A5YRynOAL.jpg"
                    },
                    new Product()
                    {
                        Name = "PlayStation 3",
                        Description = "Videgames console",
                        Price = 7000.0m,
                        Stock = 200,
                        Imagehref = "https://http2.mlstatic.com/D_NQ_NP_697806-MLA41641321269_052020-O.webp"
                    },
                    new Product()
                    {
                        Name = "PlayStation 2",
                        Description = "Videgames console",
                        Price = 1500.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/81QWa2SdU-L.jpg"
                    },
                    new Product()
                    {
                        Name = "PlayStation 1",
                        Description = "Videgames console",
                        Price = 1000.0m,
                        Stock = 200,
                        Imagehref = "https://elcomercio.pe/resizer/lmnpaIgTEQddr4DLoZqKorhTsr8=/1200x800/smart/filters:format(jpeg):quality(75)/arc-anglerfish-arc2-prod-elcomercio.s3.amazonaws.com/public/HZLWMOG5JJD5XABYLC62EPB7RI.jpg"
                    },
                    new Product()
                    {
                        Name = "Crash Bandicoot 2",
                        Description = "Crash Bandicoot 2 Cortex Strikes Back compact disk",
                        Price = 500.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/81merJfHsUL.jpg"
                    },
                    new Product()
                    {
                        Name = "Crash Bandicoot 3",
                        Description = "Crash Bandicoot 3 Warped compact disk",
                        Price = 580.0m,
                        Stock = 200,
                        Imagehref = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/182ec50c-9466-4ade-9671-b8385566d537/dg5e2tv-7361f638-bc9e-4d2d-b22d-57ea200a9824.png/v1/fill/w_833,h_959,q_70,strp/crash_bandicoot_3___ps3_greatest_hits_cover__2009__by_waynemarcelo2009_dg5e2tv-pre.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTA4MCIsInBhdGgiOiJcL2ZcLzE4MmVjNTBjLTk0NjYtNGFkZS05NjcxLWI4Mzg1NTY2ZDUzN1wvZGc1ZTJ0di03MzYxZjYzOC1iYzllLTRkMmQtYjIyZC01N2VhMjAwYTk4MjQucG5nIiwid2lkdGgiOiI8PTkzOSJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.tvXr1B_7pLJKfHtaHbjvMW_VwFaSji2vzP1maelY7e4"
                    },
                    new Product()
                    {
                        Name = "Crash Bandicoot N. Sane Trilogy",
                        Description = "Crash Bandicoot N. Sane Trilogy blueray disk",
                        Price = 2750.0m,
                        Stock = 200,
                        Imagehref = "https://cdn1.coppel.com/images/catalog/mkp/3495/3000/34951449-2.jpg"
                    },
                    new Product()
                    {
                        Name = "Laptop SONY VAIO",
                        Description = "Laptop personal computer",
                        Price = 11000.0m,
                        Stock = 200,
                        Imagehref = "https://i5.walmartimages.com.mx/mg/gm/1p/images/product-images/img_large/00081255003577l.jpg"
                    },
                    new Product()
                    {
                        Name = "Laptop TOSHIBA",
                        Description = "Laptop personal computer",
                        Price = 22000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61Ta4G8oGKL._AC_UF894,1000_QL80_.jpg"
                    },
                    new Product()
                    {
                        Name = "WIKO Phone",
                        Description = "Phone device",
                        Price = 4500.0m,
                        Stock = 200,
                        Imagehref = "https://data.wikomobile.com/documents/images/WORLD/5a1aa829ec86b7f8217a01e70f9eba1d.jpg"
                    },
                    new Product()
                    {
                        Name = "Cisco Switch 12 ports",
                        Description = "Cisco Switch network device of 12 ports",
                        Price = 17000.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61A1rwdHkZS._AC_UF894,1000_QL80_.jpg"
                    },
                    new Product()
                    {
                        Name = "Printer EPSON",
                        Description = "Color EPSON Printer",
                        Price = 2700.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/81e-sZ4o1aS._AC_UF894,1000_QL80_.jpg"
                    },
                    new Product()
                    {
                        Name = "Resistor 1K ohms",
                        Description = "Resistor 1K ohms 1/2 watt",
                        Price = 2.0m,
                        Stock = 200,
                        Imagehref = "https://m.media-amazon.com/images/I/61-ZdiAbccL.jpg"
                    },
                    new Product()
                    {
                        Name = "Potentiometer 10K",
                        Description = "Variable resistor of 10K",
                        Price = 8.0m,
                        Stock = 200,
                        Imagehref = "https://ipowerelectronics.com.mx/4767-large_default/potenciometro-de-1k-ohm.jpg"
                    },
                    new Product()
                    {
                        Name = "Transformer 12V 2A",
                        Description = "Transformer with primary of 120V 10A 60Hz, secondary of 12V 2A",
                        Price = 600.0m,
                        Stock = 200,
                        Imagehref = "https://www.srkelectronics.in/wp-content/uploads/2023/02/0-12-12V-2A-Step-Down-Transformer-srkelectronics.in_.jpeg"
                    }
                };
                foreach (Product product in products)
                {
                    dbContext.Products.Add(product);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
