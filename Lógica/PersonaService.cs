using Datos;
using Entidad;
using System;

namespace Logica
{
    public class PersonaService
    {
        readonly PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guarda(Persona persona)
        {
            try
            {
                if (personaRepository.Buscar(persona.Identificacion) == null)
                {
                    personaRepository.Guardar(persona);
                    return "Se guardaron los datos Satisfactoriamente";
                }
                return $"No fue posible Guardar la información, porque ya existe un registro con la identificaion {persona.Identificacion}";
            }
            catch (Exception e)
            {
                return $"Error inesperado al Guardar: { e.Message}";
            }
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                if (personaRepository.Buscar(identificacion) != null)
                {
                    personaRepository.Eliminar(identificacion);
                    return $"Se Eliminó el registro de la persona con identificacion{identificacion}";
                }
                return $"No fue posible eliminar el registro, porque no existe la persona con la identificacion {identificacion}";
            }
            catch (Exception e)
            {
                return $"Error inesperado al Eliminar: {e.Message}";
            }
        }

        public PersonaConsultaResponse Consultar()
        {
            try
            {
                return new PersonaConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse($"Error inesperado al Consultar: {e.Message}");
            }
        }
        public PersonaBuscarResponse Buscar(string identificacion)
        {
            try
            {
                var persona = personaRepository.Buscar(identificacion);
                if (persona == null)
                {

                    throw new PeronaNoEncontradaException("No se encontraró un registro con la identificacion Solicitada");
                }
                return new PersonaBuscarResponse(persona);
            }
            catch (PeronaNoEncontradaException e)
            {
                return new PersonaBuscarResponse("Error al Buscar:" + e.Message);
            }
            catch (Exception e)
            {
                return new PersonaBuscarResponse("Error inesperado al Buscar:" + e.Message);
            }
        }

        public string Modificiar(string identificacion, Persona personaNew)
        {
            try
            {
                if (personaRepository.Buscar(identificacion) == null)
                {
                    return $"No es posible realizar la Modificación, la persona con Identificacion {identificacion} no existe";
                }
                if (personaRepository.Buscar(personaNew.Identificacion) != null)
                {
                    return $"No es posible realizar la Modificación, La Nueva Identificación {personaNew.Identificacion} ya se encuentra asignada a otra persona";
                }
                personaRepository.Modificar(identificacion, personaNew);
                return "Se realizó la Modificación Satisfactoriamente";
            }
            catch (Exception e)
            {

                return $"Error inesperado al Modificar: {e.Message}";
            }
        }
    }
}