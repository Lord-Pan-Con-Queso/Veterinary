using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.DeleteCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectByQueries;
using ApplicationsServices.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Contexts;
using Veterinary.DomainClass.Entity;

namespace Veterinary.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        private readonly VeterinaryAppContext _context;
        public ClientController(VeterinaryAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClient([FromQuery] ClientResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectClientQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                clientName = filter.clientName,
                clientSurname = filter.clientSurname,
                IsDeleted = filter.IsDeleted,
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectClientByIdQuery { Id = id }));
        }

        //Lista las mascotas por cliente
        [HttpGet("client")]
        public async Task<IActionResult> Get()
        {
            var clients = await _context.Clients
                .Include(c => c.pets)
                .ToListAsync();
            
            string json = JsonConvert.SerializeObject(clients, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateClientCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteClientCommand { Id = id }));
        }
    }
}
