using Domain.Entities.Base;

namespace Domain.Entities;

public class Role
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    Guid RoleId { get; set; }
    List<User> Users { get; set; } = new List<User>();

    public Role(string name, string description = null)
    {
        Name = name;
        Description = description;
    }
}
