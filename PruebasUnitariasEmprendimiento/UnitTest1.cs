using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebasUnitariasEmprendimiento.Models;
namespace PruebasEmprendimiento4RI
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaCodigoIdea()
        {

            int variableEsperada = 5;
            IdeaModel pruebaIdea = new IdeaModel("Robotica", 300, 400);
            pruebaIdea.AgregarImpactosEconomicosIdea("Verde");
            pruebaIdea.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            pruebaIdea.AgregarHerramientas(3);
            pruebaIdea.AgregarHerramientas(10);
            int variableCodigo = pruebaIdea.CodigoIdea;


            Assert.AreEqual(variableEsperada, variableCodigo, 0, "El codigo no se esta generando correctamente");
        }

        [TestMethod]
        public void PruebaEstadistica1()
        {
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            string nombreIdeaEsperada = "Robotica";
            IdeaModel pruebaIdea = new IdeaModel("Robotica", 300, 400);
            pruebaIdea.AgregarImpactosEconomicosIdea("Verde");
            pruebaIdea.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            pruebaIdea.AgregarHerramientas(3);
            pruebaIdea.AgregarHerramientas(10);


            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea);

            IdeaModel pruebaIdea2 = new IdeaModel("Habeas Data", 900, 100);
            pruebaIdea2.AgregarImpactosEconomicosIdea("Rojo");
            pruebaIdea2.AgregarMiembro(78, "Karla", "lopez", "Developer", "karla6565@");
            pruebaIdea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea2);

            IdeaModel ideaImpacteMasDepartamentos = DesarrolloRegionalModel.EncontrarIdeaQueImpactaMasDepartamentos(desarrolloRegional);

            Assert.AreEqual(nombreIdeaEsperada, ideaImpacteMasDepartamentos.NombreIdea);


        }

        [TestMethod]
        public void PruebaEstadistica2()
        {
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            int inversionEsperada = 300;
            IdeaModel pruebaIdea = new IdeaModel("Robotica", 300, 400);
            pruebaIdea.AgregarImpactosEconomicosIdea("Verde");
            pruebaIdea.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            pruebaIdea.AgregarHerramientas(3);
            pruebaIdea.AgregarHerramientas(10);


            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea);

            IdeaModel pruebaIdea2 = new IdeaModel("Habeas Data", 900, 100);
            pruebaIdea2.AgregarImpactosEconomicosIdea("Rojo");
            pruebaIdea2.AgregarMiembro(78, "Karla", "lopez", "Developer", "karla6565@");
            pruebaIdea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea2);

            IdeaModel ideaImpacteMasDepartamentos = DesarrolloRegionalModel.EncontrarIdeaConMasIngresos(desarrolloRegional);

            Assert.AreEqual(inversionEsperada, ideaImpacteMasDepartamentos.InversionRequeridaIdea);


        }

        [TestMethod]
        public void PruebaEstadistica3()
        {
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            string nombrePosicion1 = "Robotica";
            IdeaModel pruebaIdea = new IdeaModel("Robotica", 300, 400);
            pruebaIdea.AgregarImpactosEconomicosIdea("Verde");
            pruebaIdea.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            pruebaIdea.AgregarHerramientas(3);
            pruebaIdea.AgregarHerramientas(10);


            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea);

            IdeaModel pruebaIdea2 = new IdeaModel("Habeas Data", 900, 100);
            pruebaIdea2.AgregarImpactosEconomicosIdea("Rojo");
            pruebaIdea2.AgregarMiembro(78, "Karla", "lopez", "Developer", "karla6565@");
            pruebaIdea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea2);

            List<IdeaModel> listaIdeasMasRentables = DesarrolloRegionalModel.EncontrarIdeasMasRentables(desarrolloRegional);

            Assert.AreEqual(nombrePosicion1, listaIdeasMasRentables[0].NombreIdea);


        }

        [TestMethod]
        public void PruebaEncontrarIdeasImpactandoMasDeTresDepartamentos()
        {
            // Arrange: Configuración inicial
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            IdeaModel pruebaIdea1 = new IdeaModel("Idea1", 300, 400);
            pruebaIdea1.AgregarImpactosEconomicosIdea("Verde");
            pruebaIdea1.AgregarImpactosEconomicosIdea("Rojo");
            pruebaIdea1.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            pruebaIdea1.AgregarHerramientas(3);
            pruebaIdea1.AgregarHerramientas(10);

            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea1);

            IdeaModel pruebaIdea2 = new IdeaModel("Idea2", 900, 100);
            pruebaIdea2.AgregarImpactosEconomicosIdea("Rojo");
            pruebaIdea2.AgregarMiembro(78, "Karla", "Lopez", "Developer", "karla6565@");
            pruebaIdea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(pruebaIdea2);


            List<IdeaModel> ideasImpactandoMasDeTresDepartamentos = DesarrolloRegionalModel.EncontrarIdeasImpactandoMasDeTresDepartamentos(desarrolloRegional);

            // Assert: Verificar los resultados
            Assert.AreEqual(2, ideasImpactandoMasDeTresDepartamentos.Count); // Ninguna de las ideas cumple con la condición
        }

        [TestMethod]
        public void PruebaCalcularIngresosTotales()
        {
            // Arrange: 
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();


            IdeaModel idea1 = new IdeaModel("Idea1", 300, 400);
            idea1.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            idea1.AgregarHerramientas(3);
            idea1.AgregarHerramientas(10);

            IdeaModel idea2 = new IdeaModel("Idea2", 900, 100);
            idea2.AgregarMiembro(78, "Karla", "Lopez", "Developer", "karla6565@");
            idea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(idea1);
            desarrolloRegional.AgregarIdeaAdesarrollo(idea2);

            // Act: 
            float ingresosTotales = desarrolloRegional.CalcularIngresosTotales(desarrolloRegional);

            // Assert: Verificar los resultados

            float ingresosEsperados = idea1.ObjetivosDeIngresosIdea + idea2.ObjetivosDeIngresosIdea;

            Assert.AreEqual(ingresosEsperados, ingresosTotales);
        }

        [TestMethod]
        public void PruebaCalcularInversionTotal()
        {
            // Arrange: 
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            // Crear algunas ideas con inversiones requeridas
            IdeaModel idea1 = new IdeaModel("Idea1", 300, 400);
            idea1.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            idea1.AgregarHerramientas(3);
            idea1.AgregarHerramientas(10);

            IdeaModel idea2 = new IdeaModel("Idea2", 900, 100);
            idea2.AgregarMiembro(78, "Karla", "Lopez", "Developer", "karla6565@");
            idea2.AgregarHerramientas(6);

            desarrolloRegional.AgregarIdeaAdesarrollo(idea1);
            desarrolloRegional.AgregarIdeaAdesarrollo(idea2);

            // Act: 
            float inversionTotal = desarrolloRegional.CalcularInversionTotal(desarrolloRegional);

            // Assert: Verificar los resultados


            float inversionEsperada = idea1.InversionRequeridaIdea + idea2.InversionRequeridaIdea;

            Assert.AreEqual(inversionEsperada, inversionTotal);
        }

        [TestMethod]
        public void PruebaEncontrarIdeaConMasHerramientas4RI()
        {
            // Arrange: Configuración inicial
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            // Crear algunas ideas con herramientas de la 4RI
            IdeaModel idea1 = new IdeaModel("Idea1", 300, 400);
            idea1.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            idea1.AgregarHerramientas(3);
            idea1.AgregarHerramientas(10);

            IdeaModel idea2 = new IdeaModel("Idea2", 900, 100);
            idea2.AgregarMiembro(78, "Karla", "Lopez", "Developer", "karla6565@");
            idea2.AgregarHerramientas(8);

            desarrolloRegional.AgregarIdeaAdesarrollo(idea1);
            desarrolloRegional.AgregarIdeaAdesarrollo(idea2);

            // Act: Llamar al método que estamos probando
            IdeaModel? ideaConMasHerramientas4RI = desarrolloRegional.EncontrarIdeaConMasHerramientas4RI(desarrolloRegional);

            // Assert: Verificar los resultados

            Assert.AreEqual(idea1, ideaConMasHerramientas4RI);
        }

        [TestMethod]
        public void PruebaContarIdeasConInteligenciaArtificial()
        {
            // Arrange: Configuración inicial
            DesarrolloRegionalModel desarrolloRegional = new DesarrolloRegionalModel();

            // Crear algunas ideas con herramientas de la 4RI, incluyendo la de Inteligencia Artificial (1)
            IdeaModel idea1 = new IdeaModel("Idea1", 300, 400);
            idea1.AgregarMiembro(45, "Juan", "Gomez", "Jefe", "juangomez@");
            idea1.AgregarHerramientas(1);

            IdeaModel idea2 = new IdeaModel("Idea2", 900, 100);
            idea2.AgregarMiembro(78, "Karla", "Lopez", "Developer", "karla6565@");
            idea2.AgregarHerramientas(2);

            IdeaModel idea3 = new IdeaModel("Idea3", 500, 600);
            idea3.AgregarMiembro(32, "Ana", "Perez", "Analista", "anaperez@");
            idea3.AgregarHerramientas(1);

            desarrolloRegional.AgregarIdeaAdesarrollo(idea1);
            desarrolloRegional.AgregarIdeaAdesarrollo(idea2);
            desarrolloRegional.AgregarIdeaAdesarrollo(idea3);

            // Act: Llamar al método que estamos probando
            int conteoIdeasConInteligenciaArtificial = desarrolloRegional.ContarIdeasConInteligenciaArtificial(desarrolloRegional);

            // Assert: Verificar los resultados
            // Las ideas 1 y 3 deberían contener herramientas de Inteligencia Artificial (1)
            // Por lo tanto, esperamos un conteo de 2
            Assert.AreEqual(2, conteoIdeasConInteligenciaArtificial);
        }








    }
}