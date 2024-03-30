namespace shelter.Domain.Models;

public class AnimalStatus
{
    public const int MAX_NAME_LENGTH = 50;

    private AnimalStatus(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; } = null!;

    public static (AnimalStatus animalStatus, string error) Create(Guid id, string name)
    {
        string error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Cтатус не может быть пустой";
        }
        else if (name.Length > MAX_NAME_LENGTH)
        {
            error = "Длина статуса не может быть больше 50";
        }

        var animalStatus = new AnimalStatus(id, name);

        return (animalStatus, error);
    }
}
