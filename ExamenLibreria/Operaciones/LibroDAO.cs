using ExamenLibreria.Context;
using ExamenLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenLibreria.Operaciones
{
    public class LibroDAO
    {
        public LibreriaExamenContext contexto = new LibreriaExamenContext();

        public List<Book> seleccionarTodos()
        {
            var libros = contexto.Books.ToList<Book>();
            return libros;
        }

        public Book seleccionar(int id)
        {
            var libros = contexto.Books.Where(a => a.Id == id).FirstOrDefault();
            return libros;
        }


        public bool insertar(string title, int author, int pages, int chapters, int price)
        {
            try
            {
                Book libro = new Book();
                libro.Title = title;
                libro.IdAuthor = author;
                libro.Pages = pages;
                libro.Chapters = chapters;
                libro.Price = price;

                contexto.Books.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<LibroAutor> seleccionarLibroAuthor()
        {
            var query = from a in contexto.Books
                        join m in contexto.Authors on a.IdAuthor
                        equals m.IdAuthor
                        select new LibroAutor
                        {
                            Title = a.Title,
                            Author = m.Name,
                            Pages = a.Pages,
                            Chapters = a.Chapters,
                            Price = a.Price
                        };
            return query.ToList();
        }

    }

}

