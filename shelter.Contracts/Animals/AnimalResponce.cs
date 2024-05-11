namespace shelter.Contracts.Animals;

public record AnimalResponce(
    string Id,
    string Name,
    int Age,
    string Description,
    string Photo,
    string SpeciesId,
    string GenderId,
    string SterilizedId,
    string AdoptionStatusId,
    string HealthStatusId,
    List<VaccinationResponce> Vaccinations);

public record VaccinationResponce(
    string Id,
    string Name,
    DateTime DateTime);