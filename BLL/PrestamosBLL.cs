using Microsoft.EntityFrameworkCore;
using RegistroPrestamos.DAL;
using RegistroPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Media.Animation;

namespace RegistroPrestamos.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.IdPersona))
            {
                return Insertar(prestamo);
            }
            else
            {
                return Modificar(prestamo);
            }
        }

        private static bool Insertar(Prestamos prestamo)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamo);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Prestamos prestamo)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(prestamo).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static bool Eliminar(int idPrestamo)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                Prestamos prestamo = contexto.Prestamos.Find(idPrestamo);

                if(prestamo != null)
                {
                    prestamo.Balance -= prestamo.Monto;
                    prestamo.Monto = 0;
                    prestamo.ConceptoPrestamo = "";
                    prestamo.IdPrestamo = 0;
                    return Modificar(prestamo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;
            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.IdPrestamo == id) || contexto.Prestamos.Any(e => e.IdPersona == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
