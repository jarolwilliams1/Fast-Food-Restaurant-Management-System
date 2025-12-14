using FastFoodManagerApp.Interfaces;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FastFoodManagerApp.Services

{

    public class MenuServices : IMenuServices
    {
        private string Nombre { get; set; }
        private decimal Precio { get; set; }
        private int Cantidad { get; set; } = 1;

        public event Action<CarritoItem> OnEliminar;

        private readonly ProductRepository _repo;
        private readonly FastFoodManagerDBContext _context;

        public MenuServices(ProductRepository repo)
        { 
        //{
        //    OnEliminar = _OnEliminar;
        //    Nombre = nombre;
        //    Precio = precio;

            //lblNombre.Text = nombre;
            //lblPrecioUnit.Text = precio.ToString("C2");
            //lblCantidad.Text = Cantidad.ToString();
            //lblTotal.Text = (Cantidad * Precio).ToString("C2");
            _repo = repo;
        }


        public void AgregrarProducto(string nombre, string catgoria,decimal precio, bool estado, string descripcion)
        {
            var product =  new Producto  { Nombre = nombre, Categoria = catgoria, Precio = precio, Descripcion = descripcion, Disponible = estado };
             _repo.AgregarProducto(product);


        }

    

    }
}
