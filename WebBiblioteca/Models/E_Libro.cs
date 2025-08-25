using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBiblioteca.Models
{
    public class E_Libro
    {
        public int ID { get; set; }
        /// <summary>
        /// Título del libro. y una breve descripción del contenido.
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Autor del libro. y mas cambios y mas cambios
        /// </summary>
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Copias { get; set; }
    }
}