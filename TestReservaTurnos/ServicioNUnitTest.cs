using ApiReservaTurnos.Controllers;
using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Domain.Models;
using ApiReservaTurnos.DTO;
using Moq;
using NUnit.Framework;
using System;

namespace TestReservaTurnos
{
    [TestFixture]
    public class ServicioNUnitTes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GuardarComercio_returnTrue()
        {
            var mocking = new Mock<IComercioService>();

            var controller = new ComercioController(mocking.Object);

            Comercio datosEntrada = new Comercio
            {
               nom_comercio = "Consultorios Médicos y Dentales",
               aforo_maximo = 15
            };

            var dato = controller.CrearComercio(datosEntrada);

            var resultado = controller.CrearComercio(datosEntrada).Id.ToString();

            Assert.AreEqual("1",resultado);
        }

        [Test]
        public void GuardarServicio_returnTrue()
        {
            var mocking = new Mock<IServicioService>();

            var controller = new ServicioController(mocking.Object);

            Servicio datosEntrada = new Servicio
            {
                id_Comercio=2,
                nom_servicio = "Ortodoncia",
                hora_apertura = new TimeSpan(9, 30, 0),
                hora_cierre = new TimeSpan(4, 00, 0),
                duracion = 40
            };

            //var valor = controller.CrearServicio(datosEntrada);

            var resultado = controller.CrearServicio(datosEntrada).Id.ToString();

            Assert.AreEqual("1", resultado);
        }

        [Test]
        public void ConsultaServicio_returnTrue()
        {
            var mocking = new Mock<IServicioService>();

            var controller = new ServicioController(mocking.Object);

            TurnoConsultaDTO datosEntrada = new TurnoConsultaDTO { 
            id_Servicio = 3,
            fecha_inicio = DateTime.Parse("10/11/2023"),
            fecha_fin = DateTime.Parse("11/11/2023")
            };

            var resultado = controller.ConsultarServicio(datosEntrada);

            Assert.IsNotNull(resultado);
        }
    }
}