using ExamenLibreria.Context;
using ExamenLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenLibreria.Operaciones
{
    public class AutorDAO
    {
        public LibreriaExamenContext contexto = new LibreriaExamenContext();

        public List<Author> seleccionarTodos()
        {
            var autor = contexto.Authors.ToList<Author>();
            return autor;
        }
        public Author seleccionar(int id)
        {
            var autor = contexto.Authors.Where(a => a.IdAuthor == id).FirstOrDefault();
            return autor;
        }
        public bool insertar(string name)
        {
            try
            {
                Author autor = new Author();
                autor.Name = name;

                contexto.Authors.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
