namespace OfficeP32.Proc;

public class GetAllEmployees
{
    public int IdEmployee { get; set; }

    public string NameEmployee { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }
    
    public int? Salary { get; set; }

    public int? PositionId { get; set; }

    public int? SkillsId { get; set; }
    
}