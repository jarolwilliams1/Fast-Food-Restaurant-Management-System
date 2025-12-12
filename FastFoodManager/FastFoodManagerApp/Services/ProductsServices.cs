using Admin.UsersControl;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;


namespace FastFoodManagerApp.Services
{
    public class ProductsServices
    {
        private readonly ProductRepository _productsRepository;
        private readonly FastFoodManagerDBContext _dbContext;
        public ProductsServices(ProductRepository productsRepository, FastFoodManagerDBContext dbContext )
        {
            _productsRepository = productsRepository;
            _dbContext = dbContext;
        }

        public List<Producto> ObtenerProductos()
        {
            return _dbContext.Productos.ToList();
        }

        public void CargarProductos()


        {

            var productos = _dbContext.Productos.ToList();

            foreach (var p in productos)
            {
                var card = new ProductoCard(p.Nombre, p.Precio);
                card.OnAgregar += AgregarAlCarrito;
                flowProductos.Controls.Add(card);
            }
        }
        private void AgregarAlCarrito(string nombre, decimal precio)
        {
            // Ver si ya existe
            foreach (CarritoItem item in flowCarrito.Controls)
            {
                if (item.Nombre == nombre)
                {
                    item.Cantidad++;
                    return;
                }
            }

            // Crear item nuevo
            var nuevo = new CarritoItem(nombre, precio);
            nuevo.OnEliminar += EliminarItemCarrito;
            flowCarrito.Controls.Add(nuevo);
        }
        private void EliminarItemCarrito(CarritoItem item)
        {
            flowCarrito.Controls.Remove(item);
        }




    }
}
