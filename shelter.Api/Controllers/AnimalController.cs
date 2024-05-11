using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using shelter.Application.Animals.Commands.CreateAnimal;
using shelter.Contracts.Animals;

namespace shelter.Api.Controllers;

[Route("animal")]
public class AnimalController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AnimalController(IMapper mapper, ISender mediator = null)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnimal(
        CreateAnimalsRequest request,
        string speciesId,
        string genderId,
        string sterilizedId,
        string adoptionStatusId,
        string healthStatusId)
    {
        var command = _mapper.Map<CreateAnimalCommand>((request, speciesId, genderId, sterilizedId, adoptionStatusId, healthStatusId));

        var createAnomalResult = await _mediator.Send(command);
        return createAnomalResult.Match(
            animal => Ok(_mapper.Map<AnimalResponce>(animal)),
            errors => Problem(errors));
    }
}
