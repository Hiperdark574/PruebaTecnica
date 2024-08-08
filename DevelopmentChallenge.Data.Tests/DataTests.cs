using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 3));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5, null) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25",resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5,null),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1,null),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3,null)

            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35",            resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Rectangulo, 5,3),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 3,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4,null),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m,null)

            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 15 | Perimeter 16 <br/>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>8 shapes Perimeter 113,66 Area 106,65",resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Rectangulo, 5,3),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 3,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4,null),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m,null)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Area 15 | Perimetro 16 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>8 formas Perimetro 113,66 Area 106,65",resumen);
        }


        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Rectangulo, 5,3),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 3,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4,null),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9,null),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m,null),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m,null)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual("<h1>Rapporti sui moduli</h1>1 Rettangolo | Area 15 | Perimetro 16 <br/>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>8 forme Perimetro 113,66 Area 106,65",resumen);

        }
    }
}
