using Entidad;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class PersonaRepository
    {
        public string ruta = @"Persona.txt";

        public void Guardar(Persona persona)
        {
            using StreamWriter escritor = new(ruta, true);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Sexo};{persona.Pulsacion}");
        }
        public List<Persona> Consultar()
        {
            List<Persona> personas = new();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new(file);
            string linea;
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                Persona persona = new()
                {
                    Identificacion = dato[0],
                    Nombre = dato[1],
                    Edad = int.Parse(dato[2]),
                    Sexo = dato[3],
                    Pulsacion = decimal.Parse(dato[4])
                };

                personas.Add(persona);
            }

            lector.Close();
            file.Close();
            return personas;
        }

        public void Modificar(string id, Persona personaNew)
        {
            List<Persona> personas = Consultar();
            File.Delete(ruta);

            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(id))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNew);
                }
            }

        }

        public void Eliminar(string id)
        {
            List<Persona> personas = Consultar();
            File.Delete(ruta);

            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(id))
                {
                    Guardar(item);
                }
            }
        }

        public Persona Buscar(string identificacion)
        {
            List<Persona> personas = Consultar();
            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}