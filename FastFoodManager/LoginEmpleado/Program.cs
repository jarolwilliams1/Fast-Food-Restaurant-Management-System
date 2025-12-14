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



  
        }
    }
    }
