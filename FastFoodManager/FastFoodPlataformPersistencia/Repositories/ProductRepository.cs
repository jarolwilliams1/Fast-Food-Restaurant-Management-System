using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodManagerPlataformDomain.Entites;

namespace FastFoodPlataformPersistencia.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly FastFoodManagerDBContext _context;

        public ProductRepository(FastFoodManagerDBContext context) 
        {
         _context = context;
        }

        public async void AgregarProducto(Producto p)
        {
            _context.Productos.Add(p);
            await _context.SaveChangesAsync();
        }

       

    }
}
