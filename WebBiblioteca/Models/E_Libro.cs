using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBiblioteca.Models
{
    /// <summary>
    /// Modelo de datos para un libro en la biblioteca. ahora habra otro cambio, y otro cambio, y otro cambio.
    /// </summary>
    public class E_Libro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Copias { get; set; }
    }
}