using PlantCare.Domain.Repositories;

namespace PlantCare.Domain.Notification;

public class Notification
{
    private readonly List<string> _errors = new List<string>();
    public IReadOnlyList<string> Errors => _errors;
    
    public void AddError(string error) =>  _errors.Add(error);
    public bool HasErrors => _errors.Any();
    
    public static readonly Notification None = new Notification();
}