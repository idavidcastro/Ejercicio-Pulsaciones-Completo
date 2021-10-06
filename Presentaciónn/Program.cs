using Entidad;
using Logica;
using System;

namespace Presentacion
{
    class Program
    {
        private static readonly PersonaService personaService = new PersonaService();
        static void Main(string[] args)
        {


            ConsoleKeyInfo continuar;
            do
            {
                Console.Clear();
                int op;
                Console.WriteLine("----------Software de Registro de Pulsaciones----------");
                Console.WriteLine("......Programacion III .....");
                Console.WriteLine("1 --> Guardar");
                Console.WriteLine("2 --> Consultar");
                Console.WriteLine("3 --> Eliminar");
                Console.WriteLine("4 --> Buscar");
                Console.WriteLine("5 --> Modificar");
                do
                {
                    Console.Write("Escoja una Opción: ");
                    op = int.Parse(Console.ReadLine());
                } while (op < 1 || op > 5);


                switch (op)
                {
                    case 1:
                        Guardar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Eliminar();
                        break;
                    case 4:
                        ConsultaPorIdentificacion();
                        break;
                    case 5:
                        Modificar();
                        break;
                }

                Console.Write("Desea Continuar en la aplicación (S/N): ");
                continuar = Console.ReadKey();
            } while (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.S);

        }

        private static void Guardar()
        {
            Console.Clear();
            Console.WriteLine("---------Ingreso de Datos---------");
            var persona = CapturarDatos();
            string mensaje = personaService.Guarda(persona);
            Console.WriteLine(mensaje);
        }

        private static void Consultar()
        {
            Console.Clear();
            Console.WriteLine("---------Consulta de Datos-----------");
            var respuesta = personaService.Consultar();
            if (respuesta.Error)
            {
                Console.WriteLine(respuesta.Mensaje);
            }
            else
            {
                foreach (var item in respuesta.Personas)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------------");
                }
            }
        }

        private static void Eliminar()
        {
            Console.Clear();
            string identificacion;
            Console.WriteLine("--------Eliminando Datos-------");
            Console.Write("Identificiacion:");
            identificacion = Console.ReadLine();
            string mensajeEliminacion = personaService.Eliminar(identificacion);
            Console.WriteLine(mensajeEliminacion);
        }


        private static void ConsultaPorIdentificacion()
        {
            Console.Clear();
            Console.WriteLine("---------Busqueda por Identificación---------");
            ValidaYMuestraPersonaBuscada();
        }

        private static void Modificar()
        {
            Console.Clear();
            Console.WriteLine("---------Información de la Persona a Modificar---------");
            var (identificacion, IsFind) = ValidaYMuestraPersonaBuscada();
            if (IsFind)
            {
                Console.WriteLine("---------Solicitando los Nuevos Datos--------- ");
                Persona persona = CapturarDatos();
                string mensaje = personaService.Modificiar(identificacion, persona);
                Console.WriteLine(mensaje);
            }

        }
        private static (string Identificacion, bool IsFind) ValidaYMuestraPersonaBuscada()
        {
            Console.Write("Identificiacion: ");
            string identificacion = Console.ReadLine();
            var mensajeBusqueda = personaService.Buscar(identificacion);
            if (mensajeBusqueda.IsError)
            {
                Console.WriteLine(mensajeBusqueda.Mensaje);
            }
            else
            {
                Console.WriteLine(mensajeBusqueda.Persona.ToString());
            }
            return (identificacion, !mensajeBusqueda.IsError);
        }

        private static Persona CapturarDatos()
        {
            Persona persona;
            string identificacion, nombre, sexo;
            int edad;
            Console.Write("Identificiacion: ");
            identificacion = Console.ReadLine();
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Edad: ");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Sexo(F/M): ");
            sexo = Console.ReadLine();
            persona = new(identificacion, nombre, edad, sexo);
            persona.CalcularPulsacion();
            Console.WriteLine($"Pulsación Estimada por 10 Seg de Ejercicio: {persona.Pulsacion}");
            return persona;
        }
    }
}