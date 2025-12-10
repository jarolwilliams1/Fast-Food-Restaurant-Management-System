using FastFoodManagerApp.Interfaces;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{


    public class RegistrarEmpleados : IRegistrarServices

    {

      // private readonly IRegistrarServices _services ;

        private readonly EmployeeRepository _repo;





        //public RegistrarEmpleados(IRegistrarServices services)
        //{
        //    _services = services;
        //}


        public RegistrarEmpleados(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public void Registrar(string Name, string apellido, string Pasword, string Rol, string usuario, ref bool Confirmar)
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





        public void IniciarSecion(string usuario, string contraseña)
        {
            var bol = true;
            if (bol)
            {
            }
        }

        public  bool IntentarLogin(string usuario, string contrasena)
        {

            var empleado = _repo.Entrar(usuario, contrasena);
            bool Confirmar = true;
            usuario = usuario.Trim();
            contrasena = contrasena.Trim();

            // Si no existe en la BD → credenciales incorrectas
            if (empleado == null || empleado.Usuario != usuario || empleado.Passwordd != contrasena)
            {
                Confirmar = false;
            }
                //return Confirmar;



            else if (empleado.Usuario == usuario && empleado.Passwordd == contrasena)
            {

                Confirmar = true;

                  
             }


            return Confirmar;
            // bool confirmar = true;
            // _repo.Entrar(usuario, contrasena);



            // if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || usuario != e.Usuario || contrasena != e.Passwordd)
            // {
            //     confirmar = false;
            //     return confirmar;
            // }

            // else if (usuario == e.Usuario && contrasena == e.Passwordd)

            // {

            //     confirmar = true;
            // }

            //return confirmar;


            //if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            //    return false;

            //// Llamada al repositorio (si valida en DB)
            //_repo.Entrar(usuario, contrasena);

            //// Si el repositorio validó correctamente:
            //if (usuario == e.Usuario && contrasena == e.Passwordd)
            //    return true;

            //return false;
        }

    }
}

