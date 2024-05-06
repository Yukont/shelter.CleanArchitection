using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shelter.Contracts.Contracts;
using shelter.Domain.Abstractions;
using shelter.Domain.Models;


namespace shelter.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class AnimalStatusController : ApiController
{
    private readonly IAnimalStatusService animalStatusService;

    public AnimalStatusController(IAnimalStatusService animalStatusService)
    {
        this.animalStatusService = animalStatusService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AnimalStatusResponce>>> GetAnimalStatuses()
    {
        /*var animalStatus = await animalStatusService.GetAllAnimalStatuses();

        var response = animalStatus.Select(a => new AnimalStatusResponce(a.Id, a.Name));*/

        return Ok();
    }
    [HttpPost]
    public async Task<ActionResult> CreateAnimalStatus([FromBody] AnimalStatusRequest request)
    {
        var (animalStatus, error) = AnimalStatus.Create(
            Guid.NewGuid(),
            request.Name);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        await animalStatusService.CreateAnimalStatus(animalStatus);

        return Ok();
    }
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAnimalStatus(Guid id, [FromBody] AnimalStatusRequest request)
    {
        var (animalStatus, error) = AnimalStatus.Create(
            id,
            request.Name);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        await animalStatusService.UpdateAnimalStatus(animalStatus);

        return Ok();
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteAnimalStatus(Guid id)
    {
        await animalStatusService.DeleteAnimalStatus(id);
        return Ok();
    }
}
