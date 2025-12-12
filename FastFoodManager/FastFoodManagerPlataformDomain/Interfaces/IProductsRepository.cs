using FastFoodManagerPlataformDomain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagerPlataformDomain.Interfaces
{
    public interface IProductsRepository
    {
        void AgregarProductos(Producto p);
    }
}
