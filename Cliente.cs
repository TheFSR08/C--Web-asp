using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaTalendig 
{
    class Cliente : ConexionBBDD
    {
        string nombre;
        List<string> ListaCliente = new List<string>();

        public Cliente(string nombre)
        {
            this.nombre = nombre;
                   
        }

        public void Agregar(string nombrex)
        {
            ListaCliente.Add(nombrex);

        }

    }
}
