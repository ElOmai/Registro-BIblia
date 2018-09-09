using RegistroBiblia.DAL;
using RegistroBiblia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroBiblia.BLL
{
    public class BibliaBLL
    {
        public static bool Guardar(Biblia Libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Libro.Add(Libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Biblia Libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Libro).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Biblia Libro = contexto.Libro.Find(id);
                contexto.Libro.Remove(Libro);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Biblia Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Biblia Libro = new Biblia();

            try
            {
                Libro = contexto.Libro.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libro;
        }

        public static List<Biblia> GetList(Expression<Func<Biblia, bool>> expression)
        {
            List<Biblia> Libro = new List<Biblia>();
            Contexto contexto = new Contexto();

            try
            {
                Libro = contexto.Libro.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libro;
        }
    }
}