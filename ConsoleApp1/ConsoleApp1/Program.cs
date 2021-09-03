using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace app3
{
    class Program
    {
        static void Main(string[] args)
        {
            char op = 's';
            string archivo = "";
            int OP;
            string nombre;

            while (op == 's')
            {
                Console.WriteLine("Que desea realizar: \n1. Crear Archivo \n2. Escribir el Archivo \n3. Ver contenido a mostar  \n4. Borrar contacto \n5. Salir ");
                OP = int.Parse(Console.ReadLine());

                Console.Clear();

                if (OP == 1)
                {
                    StreamWriter ar;
                    Console.WriteLine("Que nombre a poner: ");
                    archivo = Console.ReadLine();
                    ar = File.CreateText(archivo + ".txt");
                    nombre = archivo;

                    ar.Close();
                }
                if (OP == 2)
                {
                    EscribirArchivo(archivo);

                }
                if (OP == 3)
                {
                    MostrarContenido(archivo);

                }
                if (OP == 4)
                {
                    Borrarcontacto(archivo);

                }

                Console.ReadKey();
                if (OP == 5)
                {
                    Console.WriteLine("Quiso salir");

                }
                Console.Clear();
                Console.WriteLine("Desea Continuar ['s/n']");
                op = char.Parse(Console.ReadLine());
            }

        }
        static void EscribirArchivo(string nombre)
        {
            StreamWriter ar;
            string agenda;
            Console.WriteLine("Ingrese nomnbre: ");
            agenda = Console.ReadLine() + "/";
            Console.WriteLine("Ingrese apellido: ");
            agenda = agenda + Console.ReadLine() + "/";
            Console.WriteLine("Télefono: ");
            agenda = agenda + Console.ReadLine() + "/";
            Console.WriteLine("Ingrese dirección: ");
            agenda = agenda + Console.ReadLine() + "/";
            ar = File.AppendText(nombre);
            ar.WriteLine(agenda);
            agenda = " ";
            Console.WriteLine("Contacto a buscar: ");
            string busqueda = Console.ReadLine();
            ar.Close();

            StreamReader l;
            l = File.OpenText(nombre);

            string linea;
            linea = l.ReadLine();
            while (linea != null)
            {
                string[] vec = linea.Split('/');

                if (vec[0] == busqueda)
                {
                    Console.Write("Contacto encontrado: " + vec[0] + "" + vec[1] + "" + vec[2] + "*" + vec[3]);
                }
                linea = l.ReadLine();

            }
            l.Close();

        }
        static void MostrarContenido(string ruta)
        {
            StreamReader ar;
            ar = File.OpenText(ruta);
            Console.WriteLine(ar.ReadToEnd());
            ar.Close();
        }

        static void Borrarcontacto(string nombre)
        {
            StreamWriter are;
            string agenda = "";
            string temp = "temp.txt";

            string borrar;
            Console.WriteLine("contacto a borrar: ");
            borrar = Console.ReadLine();


            StreamReader l;
            l = File.OpenText(nombre);
            string linea;
            linea = l.ReadLine();

            StreamWriter Tar;
            Tar = File.CreateText(temp);

            while (linea != null)
            {
                string[] vec = linea.Split('/');
                if (vec[0] != borrar)
                {
                    Console.WriteLine("Contactos que no se eliminaron: " + vec[0] + "" + vec[1] + "" + vec[2] + "*" + vec[3]);
                    Tar.WriteLine(linea);
                }
                linea = l.ReadLine();
            }

            Tar.Close();
            l.Close();
            StreamReader an;
            an = File.OpenText(temp);
            StreamWriter art;
            art = File.CreateText(nombre);
            string k = an.ReadToEnd();
            art.WriteLine(k);
            an.Close();
            art.Close();

        }
    }

}
