using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetDni_ShouldThrowNacionalidadInvalidaException()
        {
            // arrange + act
            Alumno persona;

            // assert  
            Assert.ThrowsException<NacionalidadInvalidaException>(() => persona = new Alumno(1, "a", "b", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio));

        }

        [TestMethod]
        public void AddAlumno_ShouldThrowAlumnoRepetidoException()
        {
            // arrange  
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "a", "a", "11", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(1, "b", "b", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);    //solo el id/legajo es igual

            // act  
            universidad.Alumnos.Add(alumno1);
            // assert  
            Assert.ThrowsException<AlumnoRepetidoException>(() => universidad+alumno2);

        }

        [TestMethod]
        public void NewProfesor_ShouldHaveAtLeastOneClass()
        {
            // arrange  
            Profesor profesor=new Profesor(1, "a", "a", "11", Persona.ENacionalidad.Argentino);
            int expectedCantidadDeClases = 1;
            int actualCantidadDeClases = 0;
            // act  
            foreach (Universidad.EClases clase in (Universidad.EClases[])Enum.GetValues(typeof(Universidad.EClases)))
            {
                if (profesor == clase)
                {
                    actualCantidadDeClases++;
                    break;
                }
            }

            // assert  
            Assert.AreEqual(expectedCantidadDeClases, actualCantidadDeClases);

        }

        [TestMethod]
        public void NewUniversidad_ShouldNotHaveNullValues()
        {
            // arrange + act
            Universidad universidad = new Universidad();
            
            // assert  
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);

        }

    }
}
