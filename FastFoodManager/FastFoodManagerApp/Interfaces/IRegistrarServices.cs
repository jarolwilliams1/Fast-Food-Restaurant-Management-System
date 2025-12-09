using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Interfaces
{
    public interface IRegistrarServices
    {
        void Registrar(string Name, string apellido, string Pasword, string Rol, string usuario,ref bool Confirmar);
        void IniciarSecion(string usuario, string contraseña);

    }
}
