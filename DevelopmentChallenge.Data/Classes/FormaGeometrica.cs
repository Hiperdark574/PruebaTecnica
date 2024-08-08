/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Rectangulo = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3; //Nueva constante para el nuevo idioma

        #endregion

        private readonly decimal _lado;
        private readonly decimal? _altura;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho, decimal? altura)
        {
            Tipo = tipo;
            _lado = ancho;
            _altura = altura;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();
            var perimetrodescripcion = "";
            var formadescripcion = "";

            if (!formas.Any())
            {
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Lista vacía de formas!</h1>");
                        break;
                    case Ingles:
                        sb.Append("<h1>Empty list of shapes!</h1>");
                        break;
                    case Italiano:
                        sb.Append("<h1>Lista vuota di forme!</h1>");
                        break;
                }
            }
            else
            {

                var total = "";
                var area = "";
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Reporte de Formas</h1>");
                        formadescripcion = "formas";
                        perimetrodescripcion = "Perimetro";
                        total = "TOTAL";
                        area = "Area";
                        break;
                    case Ingles:
                        sb.Append("<h1>Shapes report</h1>");
                        formadescripcion = "shapes";
                        perimetrodescripcion = "Perimeter";
                        total = "TOTAL";
                        area = "Area";                        
                        break;
                    case Italiano:
                        sb.Append("<h1>Rapporti sui moduli</h1>");
                        formadescripcion = "forme";
                        perimetrodescripcion = "Perimetro";
                        total = "TOTALE";
                        area = "Area";
                        break;
                }

                var formasData = new Dictionary<string, (int cantidad, decimal area, decimal perimetro)>();

                foreach (var forma in formas)
                {
                    string tipo = forma.Tipo.ToString();

                    if (!formasData.ContainsKey(tipo))
                    {
                        formasData[tipo] = (0, 0m, 0m);
                    }

                    formasData[tipo] = (
                        formasData[tipo].cantidad + 1,
                        formasData[tipo].area + forma.CalcularArea(),
                        formasData[tipo].perimetro + forma.CalcularPerimetro());

                }


                foreach (var forma in formasData)
                {
                    sb.Append(ObtenerLinea(forma.Value.cantidad, forma.Value.area, forma.Value.perimetro, int.Parse(forma.Key), idioma,area, perimetrodescripcion));
                }
                var totalFormas = formasData.Sum(f => f.Value.cantidad);
                var totalPerimetro = formasData.Sum(f => f.Value.perimetro);
                var totalArea = formasData.Sum(f => f.Value.area);

                sb.Append(total + ":<br/>");
                sb.Append(totalFormas + " " + formadescripcion + " ");
                sb.Append(perimetrodescripcion + " " + totalPerimetro.ToString("#.##") + " ");
                sb.Append(area + " " + totalArea.ToString("#.##"));

            }
            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma, string Tarea,string Tperimetro)
        {
            if (cantidad <= 0) return string.Empty;
            return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | {Tarea} {area:#.##} | {Tperimetro} {perimetro:#.##} <br/>";
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
           switch (tipo)
            {
                case Cuadrado:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                        case Ingles:
                            return cantidad == 1 ? "Square" : "Squares";
                        case Italiano:
                            return cantidad == 1 ? "Quadrato" : "Quadrati";
                    }
                    break;
                case Circulo:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Círculo" : "Círculos";
                        case Ingles:
                            return cantidad == 1 ? "Circle" : "Circles";
                        case Italiano:
                            return cantidad == 1 ? "Cerchio" : "Cerchi";
                    }
                    break;
                case TrianguloEquilatero:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Triángulo" : "Triángulos";
                        case Ingles:
                            return cantidad == 1 ? "Triangle" : "Triangles";
                        case Italiano:
                            return cantidad == 1 ? "Triangolo" : "Triangoli";
                    }
                    break;

                case Rectangulo:
                    switch (idioma)
                    {
                        case Castellano:
                            return cantidad == 1 ? "Rectángulo" : "Rectangulos";
                        case Ingles:
                            return cantidad == 1 ? "Rectangle" : "Rectangles";
                        case Italiano:
                            return cantidad == 1 ? "Rettangolo" : "Rettangoli";
                    }
                    break;
            }
            return string.Empty;
        }

        private decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case Rectangulo: return _lado * _altura.Value;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        private decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                case Rectangulo: return 2 * (_lado + _altura.Value);
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
