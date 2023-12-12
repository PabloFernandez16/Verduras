using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS_VentaVerduras.Models;
using WS_VentaVerduras.Models.Response;
using WS_VentaVerduras.Models.ViewModels;

namespace WS_VentaVerduras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly VentaDCContext _context;
        private readonly IMapper _mapper;

        public ClienteController(VentaDCContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * **

        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var lst = _context.Clientes.ToList();
                respuesta.Exito = 1;
                respuesta.Data = lst;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var cliente = _context.Clientes.Find(id);
                respuesta.Exito = 1;
                respuesta.Data = cliente;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Add([FromBody] ClienteDTO clienteDTO)
        {
            Respuesta response = new Respuesta();
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                /*Cliente cliente = new Cliente();
                cliente.Nombre = clienteRequest.Nombre;
                cliente.Email = clienteRequest.Email;*/
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                response.Exito = 1;
                response.Data = cliente;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        // PUT api/<ClienteController>/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] ClienteDTO clienteDTO)
            {
                Respuesta response = new Respuesta();
                try
                {
                    var clienteEnBaseDatos = _context.Clientes.Find(id);

                    if (clienteEnBaseDatos != null)
                    {
                        _mapper.Map(clienteDTO, clienteEnBaseDatos);
                        _context.Entry(clienteEnBaseDatos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();

                        response.Exito = 1;
                    }
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                }

                return Ok(response);
            }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta response = new Respuesta();
            try
            {
                var clienteEnBaseDatos = _context.Clientes.Find(id);

                if (clienteEnBaseDatos != null)
                {
                    _context.Remove(clienteEnBaseDatos);
                    _context.SaveChanges();

                    response.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}
