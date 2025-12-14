using System;
using System.Windows.Forms;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;
using FastFoodManagerApp.Services;
using Menu;

namespace Menu
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. CAPA DE PERSISTENCIA - DbContext
            var context = new FastFoodManagerDBContext();
           // var ir = IPedidoRepository(context);

            // 2. CAPA DE PERSISTENCIA - Repositorios
            var productRepository = new ProductRepository(context);
            var pedidoRepository = new PedidoRepository(context);

            // 3. CAPA DE NEGOCIO - Servicios
            var productoService = new ProductoService(productRepository);
            var cajaService = new CajaService(productRepository, (IPedidoRepository)pedidoRepository);
            var pedidoService = new PedidoService((IPedidoRepository)pedidoRepository); // ✅ NUEVO

            // 4. DATOS DE SESIÓN
            int empleadoLogueadoId = 1;

            // 5. Inicializar aplicación
            ApplicationConfiguration.Initialize();

            // 6. Iniciar formulario principal
            Application.Run(new Menus(productoService, cajaService, pedidoService, empleadoLogueadoId));
        }
    }
}