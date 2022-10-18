using System;
using System.Data.SqlClient;

namespace BarberiaTalendig
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ConexionBBDD con = new ConexionBBDD();
            con.Conexion();
            con.Eleccion();
        }
    }
}
