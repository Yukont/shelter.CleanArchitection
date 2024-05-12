namespace shelter.Contracts.Animals;

public record CreateAnimalsRequest(
    string Name,
    int Age,
    string Description,
    string Photo,
    Guid SpeciesId,
    Guid GenderId,
    Guid SterilizedId,
    Guid AdoptionStatusId,
    Guid HealthStatusId,
    List<VaccinationRequest> Vaccinations
    );

public record VaccinationRequest(
    string Name, 
    DateTime DateTime);