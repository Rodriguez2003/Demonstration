using Demonstration.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demonstration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _DbContext;

        public UserController(DataContext dbContext)
        {
            _DbContext=dbContext;
        }

        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_DbContext.user.ToList());
        }

        [HttpPost("new/")]
        public IActionResult newProduct([FromForm] User request)
        {
            _DbContext.user.Add(request);
            _DbContext.SaveChanges();

            var response = new
            {
                Status = 200,
                Message = "Usuario Ingresado",
                Data = request
            };
            return Ok(response);
        }

        [HttpPut("update/")]
        public IActionResult updateProduct([FromForm] User request)
        {
            var Actualizar = _DbContext.user.Where(t =>
             t.UserId ==
             request.UserId).FirstOrDefault();

            if (Actualizar != null)
            {
                Actualizar.Nombre = request.Nombre;
                _DbContext.user.Update(Actualizar);
                _DbContext.SaveChanges();

                var response = new
                {
                    Status = 200,
                    Message = "Usuario Modificado",
                    Data = Actualizar
                };
                return Ok(response);
            }
            return StatusCode(400, "El Id no se ha encontrado :( ");
        }

        [HttpDelete("delete/")]
        public IActionResult deleteProduct([FromForm] User request)
        {
            var Eliminar = _DbContext.user.Where(t =>
             t.UserId ==
             request.UserId).FirstOrDefault();

            if (Eliminar != null)
            {
                Eliminar.UserId = request.UserId;
                _DbContext.user.Remove(Eliminar);
                _DbContext.SaveChanges();

                var response = new
                {
                    Status = 200,
                    Message = "Usuario Eliminado",
                    Data = Eliminar
                };
                return Ok(response);
            }
            return StatusCode(400, "El Id no se ha encontrado :( ");
        }
    }
}
