using FastFoodManagerPlataformDomain.Entites;


namespace FastFoodManagerPlataformDomain.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Empleado e);
         Empleado?GetById(Empleado e); // dice que el repositorio debe poder buscar un producto por id.
        void Update(Empleado e);
         void Delete(int id);
        void Create(Empleado e);
        void Entrar(string ususario, string contraseña);
    }
}
