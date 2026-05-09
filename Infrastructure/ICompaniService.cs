using Domain.Models;
using Infrastructure.Dtos;

namespace Infrastructure;


public interface ICompanyService
{
    public Task<List<Company>> GetCompaniesAsync();
    Task<List<GetCompaniesWithOrderCountDto>> GetCompaniesWithOrderCountAsync();
    public Task<Company?> GetCompanyByIdAsync(int id);
    public Task<bool> AddCompanyAsync(Company company);
    public Task<bool> UpdateCompanyAsync(Company company);
    public Task<bool> DeleteCompanyAsync(int id);
}


