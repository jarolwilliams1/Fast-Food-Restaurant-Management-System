using FastFoodManagerApp.Interfaces;
using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LoginEmpleado
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            var services = new ServiceCollection();



    //        // Registrar DbContext
    //        services.AddDbContext<FastFoodManagerDBContext>();

    //        // Registrar repositorios
    //        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    //        // Registrar servicios de aplicación
    //        services.AddScoped<IRegistrarServices, RegistrarEmpleados>();

    //        // Registrar formulario
    //        services.AddScoped<ResgistarNuevos>();

    //        var provider = services.BuildServiceProvider();

    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);

    //        Application.Run(provider.GetRequiredService<ResgistarNuevos>());

    //         var host = Host.CreateDefaultBuilder()
    //    .ConfigureServices((ctx, services) =>
    //    {
    //        services.AddDbContext<FastFoodManagerDBContext>(opts => 
    //            opts.UseSqlServer("Server=.;Database=FastFood;Trusted_Connection=True;"));
    //        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    //        services.AddScoped<RegistrarEmpleados>();
    //        services.AddScoped<ResgistarNuevos>();
    //    })
    //    .Build();
    //ApplicationConfiguration.Initialize();
    //Application.Run(host.Services.GetRequiredService<ResgistarNuevos>());
        }
    }
    }
