
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;

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

            return _context.Empleados.FirstOrDefault(e);

        }

       
    }
}
