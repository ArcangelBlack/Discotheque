using System;
using System.Threading.Tasks;
using D.Models.Enums;
using D.Models.Interfaces;
using D.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiscothequeW
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        #region Fields

        private readonly ApplicationDbContext context;

        private readonly ILogger logger;

        #endregion

        #region Constructor

        public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        #endregion

        public async Task SeedAsync()
        {
            await context.Database.MigrateAsync().ConfigureAwait(false);

            var referenceDate = System.DateTime.Now;
            var createdBy = "Auto";

            if (!await context.Rol.AnyAsync())
            {
                var iRols = new Rol[]
                {
                    new Rol(){ Description = "Admin", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Rol(){ Description = "Employee", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Rol(){ Description = "Company", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Rol(){ Description = "User", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                };

                try
                {
                    foreach (var s in iRols)
                    {
                        context.Rol.Add(s);
                    }
                    await context.SaveChangesAsync();

                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }

            // Look for any Employee.
            if (!await context.Employee.AnyAsync())
            {
                var iEmployees = new Employee[]
                {
                    new Employee()
                    {
                        Name = "Admin",  Address = "CPU", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate
                    },
                };

                try
                {
                    foreach (var s in iEmployees)
                    {
                        context.Employee.Add(s);
                    }
                    await context.SaveChangesAsync();

                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }

            // Look for any Comany.
            if (!await context.Companie.AnyAsync())
            {
                var iCompanies = new Company[]
                {
                    new Company()
                    {
                        Ruc = "114480229536",
                        Name = "Trujillo",
                        Address = "Casa",
                        Email = "as@a.com",
                        City = "Trujillo",
                        PhoneNumber = "213131",
                        CreatedBy = createdBy,
                        CreatedDate = referenceDate,
                        UpdatedBy = createdBy,
                        UpdatedDate = referenceDate
                    },
                };

                try
                {
                    foreach (var s in iCompanies)
                    {
                        context.Companie.Add(s);
                    }
                    await context.SaveChangesAsync();

                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }

            // Look for any DiscothequeCategory.
            if (!await context.DiscothequeCategorie.AnyAsync())
            {
                var iDiscothequeCategories = new DiscothequeCategory[]
                {
                    new DiscothequeCategory() { Description = "Bar", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate },
                    new DiscothequeCategory() { Description = "Restaurant", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate },
                    new DiscothequeCategory() { Description = "Discotheque", CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate },
                };

                try
                {
                    foreach (var s in iDiscothequeCategories)
                    {
                        context.DiscothequeCategorie.Add(s);
                    }
                    await context.SaveChangesAsync();

                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }
            // Look for any Discotheques.
            if (!await context.Discotheque.AnyAsync())
            {
                var iDiscotheques = new Discotheque[]
                {
                    new Discotheque(){ CompanyId = 1, Name="AMA Disco Lounge", Address ="2do piso - patio de comidas - LC 202 - CC. Real Plaza, Trujillo, Perú", Latitud = -8131.219, Longitud = -79031.698, Logo ="https://scontent.fmad7-1.fna.fbcdn.net/v/t1.0-9/15380627_10154763086542065_2485056023588449861_n.jpg?_nc_cat=0&oh=0418122470519ee21e6683a584d05a83&oe=5B5FAFA9" , PhoneNumber = "51 44 422941", Facebook    = "https://www.facebook.com/AmaDisco/?rf=118317018272435", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Discoteca", Address = "Pride Av.America Oeste 415, Trujillo, Perú", Latitud = - 8.111868, Longitud = -79.048211, Facebook = "https://www.facebook.com/pridediscotrujillo/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Paradero 21", Address ="Av.Antenor Orrego Mz A lote 1 Urb.Las Palmeras de Natasha, 13001, Perú", Latitud = -8.118151, Longitud = -79.045957, PhoneNumber = "51 997 522 540", Facebook= "https://www.facebook.com/paradero21trujillo/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="La Barra Drive Inn", Address = "Urb.San Vicente, La Marina 470, Trujillo 13008, Perú", Latitud = -8.130098, Longitud = -79.021246 , PhoneNumber= "51 44 206516", Facebook= "https://www.facebook.com/labarraperu/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Discoteca Camaleon ", Address = "Jirón Francisco Pizarro 274, Trujillo 13001, Perú", Latitud = -8.113935, Longitud = -79.029575, PhoneNumber= "51 995 252 483", Facebook  = "https://www.facebook.com/CamaleonTrujillo/",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Zentrica", Address = "Jirón Miguel Grau 572, Trujillo 13001, Perú", Latitud = -8.113581, Longitud = -79.024542, PhoneNumber = "51 995 553 083", Facebook  = "https://www.facebook.com/Zentrica-Disco-Trujillo-754683267961552/?rf=196495097366236", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Insomnio Discoteca", Address = "Jirón Francisco Pizarro, Trujillo 13001, Perú", Latitud = -8.111185, Longitud = -79.027269, Facebook = "https://www.facebook.com/Insomnia-Trujillo-182520038468114/?rf=729041950472878", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Disco Pub Mem", Address = "Trujillo, 13001, Perú", Latitud = -8.089705, Longitud = -79.040085, Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Huaka Vip", Address = "Trujillo 13007, Perú", Latitud = -8.110843, Longitud = -79.000346, Facebook = "https://www.facebook.com/HuakaVip1/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="House Disco", Address = "Jirón San Martín 809, Trujillo 13001, Perú", Latitud = -8.106585,Longitud = -79.026590,Facebook= "https://www.facebook.com/HouseDiscoPe/",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Tripulante", Address = "Jirón Independencia 577, Trujillo 13001, Perú", Latitud = -8.109871, Longitud = -79.027844, PhoneNumber= "51 930 580 242",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="HAKUNASAN", Address = "Av Prol Miraflores, Trujillo 13001, Perú", Latitud = -8.087604, Longitud = -79.017070, Status= 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Ibiza", Address = "Av. César Vallejo 1406, Trujillo 13007, Perú", Latitud = -8.100609, Longitud = -79.008915, Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="kajala", Address = "Loreto, Trujillo 13007, Perú", Latitud = -8.111400, Longitud = -79.000675, Facebook  = "https://www.facebook.com/kajala.club/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Cabildo 29", Address = "Victor Larco Herrera 13009, Perú", Latitud = -8.134033, Longitud = -79.047215, PhoneNumber  = "51 44 284495", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Discoteca My Backu", Address = "Av Túpac Amaru, Trujillo 13001, Perú", Latitud = -8.103168, Longitud = -79.023832,Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Malibu", Address = "Av 28 De Julio 269, Trujillo 13008, Perú", Latitud = -8.118116, Longitud = -79.027704, Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="El Nautico Discotek", Address = "Av. España 1238, Trujillo 13001, Perú", Latitud = -8.105551, Longitud = -79.025199, Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Praga", Address = "Av. Larco 1350, Trujillo 13008, Perú", Latitud = -8.127819, Longitud = -79.041692 , Facebook = "https://www.facebook.com/Pragavideopub/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Dejavu", Address = "Club Jiron Alfonso Ugarte 495, Trujillo 13001, Perú", Latitud = -8.114468, Longitud = -79.030291, Facebook  = "https://www.facebook.com/Dejavuclub2/", Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Insomnia", Address = "Jirón Francisco Pizarro 385, Trujillo 13001, Perú", Latitud = -8.112899, Longitud = -79.028764, PhoneNumber  = "51 947 890 002", Facebook  = "https://www.facebook.com/Insomnia-Trujillo-182520038468114/?rf=729041950472878",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Tresss Disco", Address = "Av Mansiche 2084, Trujillo 044, Perú", Latitud = -8.100661, Longitud = -79.048157, Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Discoteca Kimbara", Address = "Av.César Vallejo 1606, Trujillo 13007, Perú", Latitud = -8.098401, Longitud = -79.007202, Facebook  = "https://www.facebook.com/kimbarasalsoteca/?rf=455663427815137",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="La Casa de Valentín Segovia", Address = "Av América Norte 910, Trujillo 13001, Perú", Latitud = -8.095272, Longitud = -79.019699, PhoneNumber = "51 957 812 800",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="SAONA CLUB", Address = "Urb.Mz.Ñ Lt., Calle 4, Trujillo, Perú", Latitud = -8.111374, Longitud = -79.000707, Facebook  = "https://www.facebook.com/Saona.Club.Trujillo/",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="El Estribo Internacional", Address = "Jirón San Martín 803 - 831, Trujillo 13001, Perú", Latitud = -8.106609, Longitud = -79.026657, Facebook = "https://www.facebook.com/EstriboInternacional/",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="BROTHERS BAR", Address = "Av.Juan Pablo II Mz A5 Lt 18A., Trujillo, Perú", Latitud = -8.124644, Longitud = -79.044702, Facebook = "https://www.facebook.com/BrothersBarOficial/",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Vinos Disco Pub", Address = "Calle 2, Victor Larco Herrera 13001, Perú", Latitud = -8.095874, Longitud = -79.029542,Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Embarcadero Disco &Lounge", Address = "Av.La Marina, 442, Salaverry, Perú", Latitud = -8.220664, Longitud = -78.978833, PhoneNumber  = "51 947 868 620",Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Acústica Pub Karaoke", Address = "Jirón Diego De Almagro 849, Trujillo 13001, Perú", Latitud = -8.115490, Longitud = -79.025936,Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate},
                    new Discotheque(){ CompanyId = 1, Name="Faraon Discoteca", Address = "Av Túpac Amaru 340, Trujillo 13001, Perú", Latitud = -8.101115, Longitud = -79.025794,Status  = 1, CreatedBy = createdBy, CreatedDate = referenceDate, UpdatedBy = createdBy, UpdatedDate = referenceDate}
                };

                try
                {
                    foreach (var s in iDiscotheques)
                    {
                        context.Discotheque.Add(s);
                    }
                    await context.SaveChangesAsync();

                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }

            // Look for any User.
            if (!await context.User.AnyAsync())
            {
                var iUsers = new User[]
                {
                    new User
                    {
                        RolId = 3,
                        Name = "Josy",
                        LastName = "Farias",
                        Address = "Casa",
                        Email = "as@a.com",
                        City = "Trujillo",
                        PhoneNumber = "213131",
                        //Gender = Gender.Female,
                        CreatedBy = createdBy,
                        CreatedDate = referenceDate,
                        UpdatedBy = createdBy,
                        UpdatedDate = referenceDate
                    },
                };

                try
                {
                    foreach (var s in iUsers)
                    {
                        context.User.Add(s);
                    }
                    await context.SaveChangesAsync();
                    logger.LogInformation("Inbuilt account generation completed");
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    logger.LogInformation("Inbuilt account generation completed");
                }
            }
        }
    }
}
