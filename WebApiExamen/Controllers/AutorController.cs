using ExamenLibreria.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenLibreria.Models;
using System.Numerics;

namespace WebApiExamen.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();

        [HttpGet("autores")]
        public List<Author> getAutores()
        {
            return autorDAO.seleccionarTodos();
        }

        [HttpGet("autor")]
        public Author getAutor(int id)
        {
            return autorDAO.seleccionar(id);
        }

        [HttpPost("autores")]
        public bool insertAutor([FromBody] Author autor)
        {
            return autorDAO.insertar(autor.Name);
        } 
    }
}


