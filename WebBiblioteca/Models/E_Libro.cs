using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary> otra rama mas rama 45
namespace WebBiblioteca.Models
{
    /// <summary>
    /// Modelo de datos para un libro en la biblioteca. ahora habra otro cambio, y otro cambio, y otro cambio.
    /// </summary>
    public class E_Libro
    {
        public int ID { get; set; }
        /// <summary>
        /// Título del libro. y una breve descripción del contenido.
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Autor del libro. y mas cambios
        /// </summary>
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Copias { get; set; }
    }
}