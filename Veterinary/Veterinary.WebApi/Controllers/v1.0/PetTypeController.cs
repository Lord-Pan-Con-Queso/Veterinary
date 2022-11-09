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

namespace Veterinary.WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class PetTypeController : BaseApiController
    {
            private readonly VeterinaryAppContext _context;
            public PetTypeController(VeterinaryAppContext context)
            {
                _context = context;
            }
        
            [HttpGet]
            public async Task<IActionResult> GetAllPetType([FromQuery] PetTypeResponseFilter filter)
            {
                return Ok(await Mediator.Send(new SelectPetTypeQuery
                {
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    type = filter.type,
                    IsDeleted = filter.IsDeleted
                }));
            }

            [HttpGet("pets")]
            public async Task<IActionResult> GetAllAsync()
            {

                var petTypes = await _context.PetTypes
                    .Include(c => c.pets)
                    .ToListAsync();

                string json = JsonConvert.SerializeObject(petTypes, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Ok(json);
            }


            [HttpPost]
            public async Task<IActionResult> Post(CreatePetTypeCommand command)
            {
                return Ok(await Mediator.Send(command));
            }
            [HttpGet("{id:long}")]
            public async Task<IActionResult> GetById(long id)
            {
                return Ok(await Mediator.Send(new SelectPetTypeByIdQuery { Id = id }));
            }

            [HttpPut("{id:long}")]
            public async Task<IActionResult> Put(long id, UpdatePetTypeCommand command)
            {
                if (id != command.Id)
                    return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
                return Ok(await Mediator.Send(command));
            }

            [HttpDelete("{id:long}")]
            public async Task<IActionResult> Delete(long id)
            {
                return Ok(await Mediator.Send(new DeletePetTypeCommand { Id = id }));
            }
        }
    }
