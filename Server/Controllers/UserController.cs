using blazor_test.Server.Data;
using blazor_test.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace blazor_test.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConnectServer")]
        public async Task<ActionResult<String>> GetExample()
        {
            return "Conectado con el servidor";
        }

        [HttpGet("ConnectUserTable")]
        public async Task<ActionResult<String>> GetConnecionUserTable()
        {
            try
            {
                var response = await _context.usuario.ToListAsync();
                return "Conectado con la tabla Usuarios de la base de datos prueba_db";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("NewUser")]
        public async Task<ActionResult<String>> CreateUser(Usuario user)
        {
            if (!String.IsNullOrEmpty(user.Nombre) || !String.IsNullOrEmpty(user.Correo))
            {
                _context.usuario.Add(user);
                await _context.SaveChangesAsync();
                return "Guardado exitosamente en la base de datos";
            }
            else
            {
                return "Sin datos no se puede guardar el usuario";
            }
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<Usuario>>> GetUsers()
        {
            var users = await _context.usuario.ToListAsync();
            return users;
        }

    }
}
