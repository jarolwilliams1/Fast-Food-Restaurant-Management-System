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

            // 2. CAPA DE PERSISTENCIA - Repositorios
            var productRepository = new ProductRepository(context);
            var pedidoRepository = new PedidoRepository(context);
            var promocionRepository = new PromocionRepository(context);
            var comboRepository = new ComboRepository(context);

            // 3. CAPA DE NEGOCIO - Servicios
            var productoService = new ProductoService(productRepository);
            var cajaService = new CajaService(productRepository, pedidoRepository);
            var promocionService = new PromocionService(promocionRepository, comboRepository, productRepository);
            // 4. DATOS DE SESIÓN
            int empleadoLogueadoId = 0;
           

            // 5. Inicializar aplicación
            ApplicationConfiguration.Initialize();

            // 6. Iniciar formulario
            Application.Run(new Menus((IPromocionService)promocionService, (IProductoService)productoService, cajaService, empleadoLogueadoId));

        }
    }
}