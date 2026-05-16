using Microsoft.AspNetCore.Mvc;
using ClinicaAPI.Data;
using ClinicaAPI.Models;

namespace ClinicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public PacientesController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Pacientes.ToList());
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            // Asignar la fecha actual automáticamente al momento de registrar
            paciente.FechaRegistro = DateTime.Now;

            // Agregar el paciente al contexto de BD
            _context.Pacientes.Add(paciente);
            // Guardar cambios en la base de datos MySQL
            _context.SaveChanges();
            // Retornar el paciente registrado con código 200 OK
            return Ok(paciente);
        }
    }
}