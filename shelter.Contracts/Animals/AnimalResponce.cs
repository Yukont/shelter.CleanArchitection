namespace shelter.Contracts.Animals;

public record AnimalResponce(
    Guid Id,
    string Name,
    int Age,
    string Description,
    string Photo,
    Guid SpeciesId,
    Guid GenderId,
    Guid SterilizedId,
    Guid AdoptionStatusId,
    Guid HealthStatusId,
    List<VaccinationResponce> Vaccinations);

public record VaccinationResponce(
    Guid Id,
    string Name,
    DateTime DateTime);