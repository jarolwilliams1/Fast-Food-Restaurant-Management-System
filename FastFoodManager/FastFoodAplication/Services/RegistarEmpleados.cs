using FastFoodAplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Repositories;

namespace FastFoodAplication.Services
{
    public class RegistrarEmpleados : IRegistroServices

    {
        private readonly IRegistroServices _services = null!;

        private readonly EmployeeRepository  _repo = null! ;

        public RegistrarEmpleados (IRegistroServices services)
        {
            _services = services;
        
        }

        public RegistrarEmpleados (EmployeeRepository repo)
        {
            _repo = repo;
        }

        public async void Registrar(string usuario, string Contraseña)
        {
            var Re = new Empleado { Usuario = usuario, Passwordd = Contraseña };


             _repo.Add(Re);


        }

    }
}
