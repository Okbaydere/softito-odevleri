using OrnekProje.Model.Core;

namespace OrnekProje.Model.DTOs.IdentityDto;

public class RoleDto:EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}