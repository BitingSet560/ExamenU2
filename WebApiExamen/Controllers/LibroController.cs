using ExamenLibreria.Models;
using ExamenLibreria.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiExamen.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private LibroDAO libroDAO = new LibroDAO();


        [HttpGet("libros")]
        public List<Book> GetBooks()
        {
            return libroDAO.seleccionarTodos();
        }

        [HttpGet("libro")]
        public Book GetBook(int id)
        {
            return libroDAO.seleccionar(id);
        }

        [HttpPost("libros")]
        public bool PostBook([FromBody] Book book)
        {
            return libroDAO.insertar(book.Title, book.IdAuthor, book.Pages, book.Chapters, book.Price);
        }

        [HttpGet("libroautor")]
        public List<LibroAutor> libroAutors()
        {
            return libroDAO.seleccionarLibroAuthor();
        }


    }
}
