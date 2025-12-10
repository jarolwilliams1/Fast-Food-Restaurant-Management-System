
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
         private readonly  FastFoodManagerDBContext  _context;
       

        public EmployeeRepository(FastFoodManagerDBContext dbcontexrt)
        {
            _context = dbcontexrt;
        }

        public  async void Add(Empleado e)
        {
            _context.Empleados.Add(e);
            await _context.SaveChangesAsync();


        }
        public async void Create(Empleado e)
        {


        }

        public async void Delete(int id)
        {


        }
        public async void Update(Empleado e)
        {

        }

        public Empleado GetById(Empleado e)
        {
            //var numerosPares2 = (from n in 
            //                     where n.Nombre == e.nombre
            //                     select n).ToList();

           // var numerosPares = e.Where(n => n % 2 == 0);


            return _context.Empleados.FirstOrDefault(e);


        }

        public Empleado Entrar(string usuario, string contraseña)
        {
            Empleado e = new Empleado();
            var ususarioEncontrr = _context.Empleados.FirstOrDefault(e => e.Usuario == usuario

            && e.Passwordd == contraseña);



            return e;




        }


    }
}
