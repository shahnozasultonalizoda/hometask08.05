namespace Infrastructure.Dtos;

public class GetCompaniesWithOrderCountDto
{
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public int OrderCount { get; set; }

}
