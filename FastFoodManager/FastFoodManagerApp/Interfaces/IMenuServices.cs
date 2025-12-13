using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;


namespace FastFoodManagerApp.Interfaces
{
    public interface IMenuServices
    {
        void AgregrarProducto(string nombre, string catgoria, decimal precio, bool estado, string descripcion);
    }
}
