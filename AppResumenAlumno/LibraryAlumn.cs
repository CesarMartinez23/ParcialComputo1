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

        static readonly string _FilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resumenes");

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
                    var studentFiles = new Dictionary<string, string>() {
                { "SMIS055621", "Este computo estuvo lleno de mucho aprendizaje," +
                " nos correspondió aprender un nuevo lenguaje de programación, C#, " +
                "en lo personal nunca había trabajado con este lenguaje y fue satisfactorio," +
                " ya que a medida pasaban las clases aprendida a cómo utilizarlo," +
                " nos correspondió estar trabajando con git, " +
                "que esta plataforma permite a los desarrolladores descargar un software, " +
                "realizar cambios y subir la versión que han modificado, " +
                "es decir, que permite la fácil interacción para la creación de proyectos. " +
                "Además, aprendimos como utilizar los métodos, archivos, assemblies, bucles, " +
                "referencias, bibliotecas, entre otros elementos. Por otra parte, aprendí como crear ramas en git, " +
                "los diferentes comandos que se necesitan para crearlos desde Git Bash Here, " +
                "pero también cabe destacar que se puede realizar directamente desde Visual Studio, " +
                "es una forma de acorta el procedimiento, diversos elementos que adquirimos durante este computo."},

                { "SMIS537818", "En lo personal este computo estuvo lleno de nuevas experiencias y conocimientos, estuvimos trabajando con Visual Studio Community, integrando con C#, aprendimos como utilizar los bucles, archivos, algo que muchos no conocíamos como los son las bibliotecas, referencias, así como también los assemblies, algo que para mí fue un poco difícil pero que con la practica se pudo comprender mejor. Además, cabe destacar que utilizamos git, que es un software donde subíamos nuestros proyectos, lo interesante es que podíamos trabajar en conjunto, ya que aprendimos a crear ramas dentro de git, lo que permitía que hubiese varios colaborados modificando un mismo proyecto, es increíble lo que se puede crear con pequeños comandos, teniendo en cuenta que la mejor forma de entender y adquirir un conocimiento es por medio de la práctica."},
                { "SMIS063521", "En el presente computo hemos trabajado diferentes proyectos, tomando temas directamente con entorno de programación, que ha sido empaquetado como un programa de aplicación lo cual tiene diferentes funcionalidades, siendo este más complejo y es el visual estudio 2019, también se a adquirido la experiencia de trabajar con repositorios de git, puesto que gracias a eso tendremos una mayor eficacia, compatibilidad y entre otros factores importantes que facilitan el uso de los códigos. Además, se han trabajado los bucles o ciclos que generan una secuencia repetitiva de una determinada instrucción, esta finaliza hasta que la condición que se ha asignado se cumple, de lo contrarios nunca cesara de gestionarse. Podría decir que lo que más me a costado aprender a sido el ciclo do-while, y me ha gustado el manejo del while y el ciclo for."},
                { "SMIS083121", "Durante el cómputo hemos trabajado diferentes proyecto en lo que es el entorno de desarrollo integrado IDE lo cual es un entorno de programación que ha sido empaquetado como un programa de aplicación lo cual tiene como diferente funcionalidades, llámese un editor de código , un depurador y un editor de código el cual es una herramienta que está integrada a Visual Studio 2019 , además se ha adquirido conocimientos previos a la  creación de repositorio en Git el cual es un software de control de versiones diseñado por Linus Torvalds, pensando en la eficiencia, la confiabilidad y compatibilidad del mantenimiento de versiones de aplicaciones cuando estas tienen un gran número de archivos de código fuente. Por otra parte en la ejecución de códigos se han trabajado los  bucle o ciclo lo cual  es una secuencia de instrucciones de código que se ejecuta repetidas veces, hasta que la condición asignada a dicho bucle deja de cumplirse. Del manejo de los bucles que más he aprendido a manejar está el while, el ciclo for, el ciclo do-while."}
            };

                    foreach (var student in studentFiles)
                    {
                        CreateArchivos(student.Key, student.Value);
                    }
                    Console.WriteLine("\n");
                    break;
                case 3:
                    MostrarArchivos();
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
                    LeerArchivo();
                    break;
                case 2:
                    MetodoLogin();
                    break;
            }
        }

        static void CreateArchivos(string fileName, string content, string extension = ".txt")
        {
            if (!Directory.Exists(_FilesPath))
                Directory.CreateDirectory(_FilesPath);

            var path = Path.Combine(_FilesPath, $"{fileName}{extension}");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(content);
                    sw.Close();
                }
                Console.WriteLine($"Se creo el archivo {fileName} correctamente.");

            }
            else
            {
                Console.WriteLine($"El archivo {fileName} ya existe en la ruta.");
            }
        }

        static void MostrarArchivos()
        {
            int ind = 1;
            var archivos = Directory.GetFiles(_FilesPath);

            Console.WriteLine("*******************");
            Console.WriteLine("Listado de archivos");
            Console.WriteLine("*******************");

            foreach (var archivo in archivos)
            {
                var archivoName = archivo.Split('\\');
                Console.WriteLine($"{ind}- " + archivoName[archivoName.Length - 1]);
                ind++;
            }

        }

        static int SeleccionarArchivo(string texto)
        {
            Console.WriteLine(texto);
            int opc = int.Parse(Console.ReadLine());

            return opc;
        }

        static void LeerArchivo()
        {
            MostrarArchivos();
            int opc = SeleccionarArchivo("Seleccione el numero que corresponde al archivo que desee visualizar.");

            var archivos = getFiles();

            string readText = File.ReadAllText(getFileByIndex(opc - 1));
            Console.WriteLine(readText);

        }

        static string[] getFiles()
        {
            return Directory.GetFiles(_FilesPath);

        }

        static string getFileByIndex(int index)
        {
            var files = getFiles();

            return files[index];
        }


    }
}
