using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppResumenAlumno
{
    public class LibraryAlumn
    {
        public class UserClases
        {
            public string user { get; set; }
            public string clave { get; set; }
        }

        public static List<UserClases> users = new List<UserClases>();
        public static int Reintentos = 3;

        public static void Alumn()
        {
            while (true)
            {
                if (Reintentos == 0)
                {
                    break;
                }

                MetodoLogin();

            }

            Console.WriteLine("Lo intentaste 3 veces, lo sentimos, vuelve a intentarlo nuevamente, le consultaremos al admin.");
            Console.ReadKey();

        }

        static void MetodoLogin()
        {
            bool typeUser;
            string[] usuario = new string[2];
            usuario = logindatos(usuario);

            typeUser = adminUser(usuario[0], usuario[1]);

            if (typeUser == true)
            {
                menuAdmin();
            }
            else
            {
                if (search(usuario[0], usuario[1]))
                {
                    menuOtros();
                }
                else
                {
                    Reintentos--;
                    Console.WriteLine("No se encontro en los registros. Lo has intentado: " + Reintentos + " veces.");
                }
            }
        }

        static bool adminUser(string user, string password)
        {
            return user == "admin" && password == "123";
        }

        static string[] logindatos(string[] data)
        {
            Console.WriteLine("\n");
            Console.WriteLine("******************************");
            Console.WriteLine("Bienvenido al Inicio de Sesion");
            Console.WriteLine("******************************");
            Console.WriteLine("\n");
            Console.Write("Nombre de Usuario: ");
            string user = Console.ReadLine();
            data[0] = user;
            Console.Write("Password: ");
            string password = Console.ReadLine();
            data[1] = password;

            return data;
        }

        static bool search(string user, string password)
        {
            UserClases userall = users.Find(usr => usr.user == user && usr.clave == password);
            return userall != null;
        }

        static void menuAdmin()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**********");
            Console.WriteLine("Menu Admin");
            Console.WriteLine("**********");
            Console.WriteLine("\n");
            Console.WriteLine("1- Registrar Usuarios.");
            Console.WriteLine("2- Crear Archivos.");
            Console.WriteLine("3- Borrar Archivo.");
            Console.WriteLine("4- Salir.");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\n");
                    Console.WriteLine("**********************************");
                    Console.WriteLine("Bienvenido al Registro de Usuarios");
                    Console.WriteLine("**********************************");
                    Console.WriteLine("\n");
                    Console.WriteLine("--------Registrar Usuario--------");
                    Console.WriteLine("\n");
                    Console.Write("Nombre de Usuario: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Password: ");
                    string contrasenia = Console.ReadLine();
                    users.Add(new UserClases() { user = nombre, clave = contrasenia });

                    menuAdmin();

                    break;
                case 2:
                    
                    Console.WriteLine("Los archivos se crearon correctamente en la ruta establecida.");
                    Console.WriteLine("\n");
                    break;
                case 3:

                    break;

                case 4:
                    MetodoLogin();
                    break;
            }
        }

        static void menuOtros()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Menu Otros");
            Console.WriteLine("**********");
            Console.WriteLine("\n");
            Console.WriteLine("1- Ver Archivos.");
            Console.WriteLine("2- Salir.");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
           
                    break;
                case 2:
                    MetodoLogin();
                    break;
            }
        }
       
    }
}
