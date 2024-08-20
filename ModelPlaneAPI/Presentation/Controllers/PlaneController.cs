using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelPlaneApp.Application.Commands;
using ModelPlaneApp.Application.Queries;

namespace ModelPlaneApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanes()
        {
            var query = new GetAllPlanesQuery();
            var planes = await _mediator.Send(query);
            return Ok(planes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlane(Guid id)
        {
            var query = new GetPlaneByIdQuery { Id = id };
            var plane = await _mediator.Send(query);

            if (plane == null)
            {
                return NotFound();
            }

            return Ok(plane);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlane([FromBody] CreatePlaneCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid plane data.");
            }

            var planeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPlane), new { id = planeId }, planeId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlane(Guid id, [FromBody] UpdatePlaneCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlane(Guid id)
        {
            var command = new DeletePlaneCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
