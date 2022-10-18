using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BarberiaTalendig
{
    public class ConexionBBDD 
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public string nombre;
         

        public void Conexion()
        {
            try
            {

                con = new SqlConnection("SERVER=FSR;DATABASE=Barbery;Integrated Security=True");
                con.Open();

                Console.WriteLine("me he conectado a la base de datos");

            }
            catch (Exception s)
            {
                Console.WriteLine("error al conectar" + s.Message);
            }


        }

        public String InsertarCliente(String nombre, int id)
        {
            String Salida = "Insercion correcta";

            try
            {
               
                cmd = new SqlCommand("insert into cliente(id,nombre) values("+id + nombre + ")", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine(nombre + "se ha agregado");

            }
            catch (Exception ex)
            {
                String salida = "no se conecto" + ex.ToString();
            }
            return Salida;
        }

        public String InsertarCorte(String nombre, int precio)
        {
            String Salida = "Insercion correcta";

            try
            {
                con.Open();
                cmd = new SqlCommand("insert into corte(nombre,precio) values(" + nombre + precio + ")", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String salida = "no se conecto" + ex.ToString();
            }
            return Salida;
        }
        public String InsertarServicios(int idCorte, int idCliente, DateTime t3)
        {
            String Salida = "Insercion correcta";

            try
            {
                cmd = new SqlCommand("insert into servicios(id_cliente,id_corte,fecha) values(" + idCliente + idCorte + t3 + ")", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String salida = "no se conecto" + ex.ToString();
            }
            return Salida;
        }
    

        public String  VerCliente(String datos)
        {
           
            datos = "select * from cliente ";

            String Salida = "peticion correcta";

            try
            {
                
                cmd = new SqlCommand(datos, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String salida = "no se conecto" + ex.ToString();
            }
            return Salida;

        }

        public void VerServicios(String dato)
        {
             dato = "select * from servicios ";

        }

        public void VerCortes(String dato)
        {
             dato = "select * from corte ";

            String Salida = "peticion correcta";

            try
            {

                cmd = new SqlCommand(dato, con);
                cmd.ExecuteNonQuery();


                Console.WriteLine(Salida);
            }
            catch (Exception ex)
            {
                String salida = "no se conecto" + ex.ToString();
            }
            

        }

        public void validarDatos(string nombre)
        {
            if (nombre == "")
            {
                Console.WriteLine("no se permiten campos vacios");
            }
        }

        public void validarCorte(string nombre, int precio)
        {
            if (nombre == "" || precio == 0) ;
            {
                Console.WriteLine("no se permiten campos vacios");
            }
        }

        public void Eleccion()
        {
            Console.WriteLine("---------------------------------- BIENVENIDO A LA SUCULENTA BARBERIA TALENDIG ----------------------------------");
            Console.WriteLine("\n--------- FAVOR ELIJA LA OPCION DESEADA PARA PROCEDER ----------\n");
            Console.WriteLine("1. Agregar Cliente.");
            Console.WriteLine("2. agregar tipo de Corte y su precio.");
            Console.WriteLine("3. Agregar Servicio.");
            Console.WriteLine("4. ver clientes");
            Console.WriteLine("5. ver servicios");
            Console.WriteLine("6. ver tipos de corte");

            try {
                int opcion = int.Parse(Console.ReadLine());
                Conexion();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n --------- HAS ELEGIDO AGREGAR CLIENTE ---------");
                        Console.WriteLine("\n favor insertar el nombre del cliente.");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("\n favor insertar el id del cliente.");
                        int id = int.Parse(Console.ReadLine());
                        validarDatos(nombre);
                        InsertarCliente(nombre, id);
                        Eleccion();
                        break;
                    case 2:
                        Console.WriteLine("\n --------- HAS ELEGIDO AGREGAR TIPO DE CORTE Y PRECIO ---------");
                        Console.WriteLine("\n Insertar nombre del corte");
                        string nombreCorte = Console.ReadLine();
                        Console.WriteLine("\n Insertar el precio de corte");
                        int precio = int.Parse(Console.ReadLine());
                        validarCorte(nombreCorte, precio);
                        InsertarCorte(nombreCorte, precio);
                        Eleccion();
                        break;
                    case 3:
                        Console.WriteLine("\n --------- HAS ELEGIDO AGREGAR SERVICIO ---------");
                        InsertarServicios(0, 0, DateTime.Now);
                        Eleccion();
                        break;
                    case 4:
                        Console.WriteLine("\n -------- CLIENTES EXISTENTES -----------");
                        VerCliente("");
                        Eleccion();
                        break;
                    case 5:
                        Console.WriteLine("\n -------- SERVICIOS REALIZADOS ----------");
                        VerServicios("");
                        Eleccion();
                        break;
                    case 6:
                        Console.WriteLine("\n---- TIPOS DE CORTES DE CABELLOS -----");
                        VerCortes("");
                        Eleccion();
                        break;
                        

                }
            
            } catch (Exception e) { 
                Console.WriteLine("opcion invalida favor reintentar ( "+e.Message+" )");
                Eleccion();
            }
        }
    
}
}         
        
        
        
        

    
