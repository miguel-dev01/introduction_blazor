using blazor_test.Server.Data;
using blazor_test.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blazor_test.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConnectMovementTable")]
        public async Task<ActionResult<String>> GetConnecionMovementTable()
        {
            try
            {
                var response = await _context.Movimiento.ToListAsync();
                return "Conectado con la tabla Movimiento de la base de datos prueba_db";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("NewMovement")]
        public async Task<ActionResult<String>> CreateMovimiento(Movimiento objeto)
        {
            _context.Movimiento.Add(objeto);
            await _context.SaveChangesAsync();
            return "Guardado con Exito";
        }

        [HttpGet("GetMovements")]
        public async Task<ActionResult<List<Movimiento>>> GetMovements() 
        { 
            var movimientos = await _context.Movimiento.Include(u => u.Usuario).ToListAsync();
            return movimientos;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<String>> DeleteMovimiento(int id)
        {
            var DbObjeto = await _context.Movimiento.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }
            _context.Movimiento.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return "Eliminado!!";
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<String>> UpdateMovimiento(Movimiento movimiento)
        {
            var DbObjeto = await _context.Movimiento.FindAsync(movimiento.Id);
            if (DbObjeto == null)
            {
                return BadRequest("No encontrado");
            }
            DbObjeto.Fecha = movimiento.Fecha;
            DbObjeto.Cantidad = movimiento.Cantidad;
            DbObjeto.Tipo = movimiento.Tipo;
            DbObjeto.Descripcion = movimiento.Descripcion;
            DbObjeto.UsuarioId = movimiento.UsuarioId;

            await _context.SaveChangesAsync();

            return "Actualizado correctamente";
        }

    }
}
