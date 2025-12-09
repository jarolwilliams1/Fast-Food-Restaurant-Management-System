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

        private readonly IRegistrarServices _services;

        private readonly EmployeeRepository _repo ;

       



        public RegistrarEmpleados(IRegistrarServices services)
        {
            _services = services;
        }


        public RegistrarEmpleados(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public void Registrar(string Name, string apellido, string Pasword, string Rol, string usuario,ref bool Confirmar)
            {
            try
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(Pasword) || string.IsNullOrEmpty(Rol) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(Name))
                {
                    Confirmar = false;
                    throw new Exception("Los Campos no pueden estar VACIOS!");
                }
                else
                {
                    Confirmar = true;
                }

                var Re = new Empleado { Usuario = usuario, Passwordd = Pasword, Rol = Rol, Apellido = apellido, Nombre = Name };


                _repo.Add(Re);
            }
            catch (Exception) 
            {
                Confirmar = false;
                //throw new Exception("Hubo un error, intente nuevamente");
                

            }


        }



        }

    }

