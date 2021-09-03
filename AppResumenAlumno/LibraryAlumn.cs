using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void Alumn()
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
                menuOtros();
            }
            Console.ReadKey();
        }


        static bool adminUser(string user, string password)
        {
            if (user == "admin" && password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string[] logindatos(string[] data)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al Inicio de Sesion");
            Console.WriteLine("Nombre de Usuario:");
            string user = Console.ReadLine();
            data[0] = user;
            Console.WriteLine("Password:");
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
            Console.WriteLine("Menu");
            Console.WriteLine("1- Registrar Usuarios");
            Console.WriteLine("2- Crear archivos");
            Console.WriteLine("3- Borrar Archivo");
            Console.WriteLine("4- Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Registrar Usuario");
                    Console.WriteLine("Nombre de Usuario:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Password:");
                    string contrasenia = Console.ReadLine();
                    users.Add(new UserClases() { user = nombre, clave = contrasenia });

                    menuAdmin();

                    break;
                case 2:
                    break;
                case 3:
                    break;

                case 4:
                    string[] usuario = new string[2];
                    usuario = logindatos(usuario);
                    break;
            }
        }

        static void menuOtros()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1- Ver Archivos");
            Console.WriteLine("2- Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:

                    break;
                case 2:
                    break;
            }
        }

    }
}
