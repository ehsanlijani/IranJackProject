namespace IranJackProject.Domain.Models.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
