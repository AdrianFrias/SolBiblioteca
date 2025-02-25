using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBiblioteca.Datos;
using WebBiblioteca.Models;

namespace WebBiblioteca.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            List<E_Libro> coleccion = new List<E_Libro>();
            D_Libro datos = new D_Libro();
            try
            {
                coleccion = datos.ObtenerBiblioteca();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"{ex.Message}";
            }
            return View("Principal", coleccion);
        }
        public ActionResult VistaAgregar()
        {
            return View("NuevoLibro");
        }
        public ActionResult AgregarLibro(E_Libro libroNuevo)
        {
            try
            {
                if (libroNuevo.Copias > 0)
                {
                    D_Libro datos = new D_Libro();
                    datos.AgregarNuevoLibro(libroNuevo);
                    TempData["mensaje"] = $"Libro {libroNuevo.Titulo} agregado a la biblioteca";

                }
                else
                {
                    TempData["errorvalidacion"] = $"Ingrese un numero de copias valido";
                    return RedirectToAction("VistaAgregar");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");
        }
        public ActionResult VistaEditar(int ID)
        {
            E_Libro libroEditar = new E_Libro();
            D_Libro datos = new D_Libro();
            try
            {
                libroEditar = datos.ObtenerLibro(ID);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return RedirectToAction("Index");
            }

            return View("ActualizarLibro", libroEditar);
        }
        public ActionResult EditarLibro(E_Libro LibroEditado)
        {
            try
            {
                if (LibroEditado.Copias > 0)
                {
                    D_Libro datos = new D_Libro();
                    datos.ActualizarLibro(LibroEditado);
                    TempData["mensaje"] = $"Libro {LibroEditado.ID}:{LibroEditado.Titulo} actualizado";
                }
                else
                {
                    TempData["errorvalidacion"] = $"Ingrese un numero de copias valido";
                    //Es como mandar /Inicio/VistaEditar/?ID=5
                    return RedirectToAction("VistaEditar", new { ID = LibroEditado.ID });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");
        }
        public ActionResult VistaBorrar(int ID)
        {
            E_Libro libroEditar = new E_Libro();
            D_Libro datos = new D_Libro();
            try
            {
                libroEditar = datos.ObtenerLibro(ID);

            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return RedirectToAction("Index");
            }

            return View("EliminarLibro", libroEditar);
        }
        public ActionResult BorrarLibro(E_Libro LibroEliminado, string Eliminar)
        {
            D_Libro datos = new D_Libro();
            try
            {
                if (Eliminar == "SI")
                {
                    datos.EliminarLibro(LibroEliminado.ID);
                    TempData["mensaje"] = $"Libro  {LibroEliminado.ID}:\"{LibroEliminado.Titulo}\" eliminado";
                }
                else
                {
                    TempData["mensaje"] = $"Eliminacion de \"{LibroEliminado.Titulo}\" CANCELADA";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");

        }
        public ActionResult VistaPrestamo()
        {
            return View("PrestamoLibro");
        }
        public ActionResult PrestarLibro(int Codigo, int Cantidad)
        {
            E_Libro Libro = new E_Libro();
            D_Libro datos = new D_Libro();
            try
            {
                Libro = datos.ObtenerLibro(Codigo);
                if (Libro.Titulo != null)
                {
                    if (Cantidad > 0)
                    {
                        if (Cantidad > Libro.Copias)
                        {
                            TempData["errorvalidacion"] = $"No hay copias suficientes para el libro de \"{Libro.Titulo}\"";
                            return RedirectToAction("VistaPrestamo");
                        }
                        else
                        {
                            Libro.Copias -= Cantidad;
                            datos.ActualizarLibro(Libro);
                            TempData["mensaje"] = $"{Cantidad} Libro(s) de {Libro.ID}:{Libro.Titulo} prestados";
                        }

                    }
                    else
                    {
                        TempData["errorvalidacion"] = $"Ingrese un numero de copias valido";
                        return RedirectToAction("VistaPrestamo");
                    }
                }
                else
                {
                    TempData["errorvalidacion"] = $"No existe el libro con el ID:{Codigo}";
                    return RedirectToAction("VistaPrestamo");

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");
        }
        public ActionResult VistaDevolucion()
        {
            return View("DevolucionLibro");
        }
        public ActionResult DevueltoLibro(int Codigo, int Cantidad)
        {
            E_Libro Libro = new E_Libro();
            D_Libro datos = new D_Libro();
            try
            {
                Libro = datos.ObtenerLibro(Codigo);

                if (Libro.Titulo != null)
                {
                    if (Cantidad > 0)
                    {
                        Libro.Copias += Cantidad;
                        datos.ActualizarLibro(Libro);
                        TempData["mensaje"] = $"{Cantidad} Libro(s) devueltos de {Libro.ID}:{Libro.Titulo}";
                    }
                    else
                    {
                        TempData["errorvalidacion"] = $"Ingrese un numero de copias valido";
                        return RedirectToAction("VistaDevolucion");
                    }
                }
                else
                {
                    TempData["errorvalidacion"] = $"No existe el libro con el ID:{Codigo}";
                    return RedirectToAction("VistaDevolucion");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}