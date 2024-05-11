namespace shelter.Contracts.Animals;

public record CreateAnimalsRequest(
    string Name,
    int Age,
    string Description,
    string Photo,
    List<VaccinationRequest> Vaccinations
    );

public record VaccinationRequest(
    string Name, 
    DateTime DateTime);