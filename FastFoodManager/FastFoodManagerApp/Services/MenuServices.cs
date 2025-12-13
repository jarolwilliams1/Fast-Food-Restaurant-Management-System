using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodManagerApp.Interfaces;
using FastFoodPlataformPersistencia.Repositories;
using FastFoodManagerPlataformDomain.Entites;


namespace FastFoodManagerApp.Services

{

    public class MenuServices : IMenuServices
    {
        private readonly ProductRepository _repo;

        public MenuServices(ProductRepository repo)
        {
            _repo = repo;
        }


        public void AgregrarProducto(string nombre, string catgoria,decimal precio, bool estado, string descripcion)
        {
            var product =  new Producto  { Nombre = nombre, Categoria = catgoria, Precio = precio, Descripcion = descripcion, Disponible = estado };
             _repo.AgregarProducto(product);


        }

    }
}
