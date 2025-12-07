using FastFoodManagerApp.Interfaces;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{
   

        public class RegistrarEmpleados : IRegistrarServices

        {

        //private readonly IRegistrarServices _services ;

        private readonly EmployeeRepository _repo;


       
        //public RegistrarEmpleados(IRegistrarServices services)
        //{
        //    _services = services;
        //} 


        public RegistrarEmpleados(EmployeeRepository repo)
        {
            _repo = repo;
        } 

        public void Registrar(string usuario, string Contraseña)
            {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(Contraseña))
            {
                throw new Exception("Los Campos no pueden estar VACIOS!");
            }
            var Re = new Empleado { Usuario = usuario, Passwordd = Contraseña };


                _repo.Add(Re);


            }



        }

    }

