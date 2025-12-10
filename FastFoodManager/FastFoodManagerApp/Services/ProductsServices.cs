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

       


    }
}
