using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class CorreoTests
    {
        /// <summary>
        /// Verifica que la lista de Paquetes del Correo esté instanciada
        /// </summary>
        [TestMethod]
        public void CorreoPaquetes_ShouldBeInstantiated()
        {
            //Arrange + Act
            Correo correo = new Correo();

            //Assert
            Assert.IsNotNull(correo.Paquetes);

        }

        /// <summary>
        /// Verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        public void PaqueteRepetido_ShouldThrowTrackingIdRepetidoException()
        {
            //Arrange
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("a", "1");
            Paquete paquete2 = new Paquete("b", "1");

            //Act
            correo += paquete1;

            //Assert
            Assert.ThrowsException<TrackingIdRepetidoException>(() => correo + paquete2);

        }


    }
}
