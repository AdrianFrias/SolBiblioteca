using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBiblioteca.Models;

namespace WebBiblioteca.Datos
{
    public class D_Libro
    {
        private string cadenaconexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        public List<E_Libro> ObtenerBiblioteca()
        {
            List<E_Libro> coleccion = new List<E_Libro>();
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();
                string query = "SELECT IDLibro,Titulo,Autor,Genero,Copias FROM Biblioteca";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    E_Libro libro = new E_Libro();
                    libro.ID = Convert.ToInt32(reader["IDLibro"]);
                    libro.Titulo = Convert.ToString(reader["Titulo"]);
                    libro.Autor = Convert.ToString(reader["Autor"]);
                    libro.Genero = Convert.ToString(reader["Genero"]);
                    libro.Copias = Convert.ToInt32(reader["Copias"]);
                    coleccion.Add(libro);
                }
                conexion.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return coleccion;
        }
        public void AgregarNuevoLibro(E_Libro libroNuevo)
        {
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();
                string query = "INSERT INTO Biblioteca(Titulo,Autor,Genero,Copias) " +
                    "VALUES (@titulo,@autor,@genero,@copias)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@titulo", libroNuevo.Titulo);
                comando.Parameters.AddWithValue("@autor", libroNuevo.Autor);
                comando.Parameters.AddWithValue("@genero", libroNuevo.Genero);
                comando.Parameters.AddWithValue("@copias", libroNuevo.Copias);

                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public E_Libro ObtenerLibro(int ID)
        {
            E_Libro editar = new E_Libro();
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();
                string query = "SELECT IDLibro,Titulo,Autor,Genero,Copias FROM Biblioteca WHERE IDLibro=@id";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", ID);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    editar.ID = Convert.ToInt32(reader["IDLibro"]);
                    editar.Titulo = Convert.ToString(reader["Titulo"]);
                    editar.Autor = Convert.ToString(reader["Autor"]);
                    editar.Genero = Convert.ToString(reader["Genero"]);
                    editar.Copias = Convert.ToInt32(reader["Copias"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return editar;
        }
        public void ActualizarLibro(E_Libro libroEditado)
        {
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();
                string query = "UPDATE Biblioteca " +
                    "SET Titulo=@titulo,Autor=@autor,Genero=@genero,Copias=@copias " +
                    "WHERE IDLibro=@id";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", libroEditado.ID);
                comando.Parameters.AddWithValue("@titulo", libroEditado.Titulo);
                comando.Parameters.AddWithValue("@autor", libroEditado.Autor);
                comando.Parameters.AddWithValue("@genero", libroEditado.Genero);
                comando.Parameters.AddWithValue("@copias", libroEditado.Copias);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void EliminarLibro(int ID)
        {
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();
                string query = "DELETE FROM Biblioteca WHERE IDLibro=@id";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", ID);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void PrestamoLibro(E_Libro Libro,int cantidad)
        {
            SqlConnection conexion = new SqlConnection(cadenaconexion);
            try
            {
                conexion.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}