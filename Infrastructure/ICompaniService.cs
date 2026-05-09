using Domain.Models;

namespace Infrastructure;


public interface ICompanyService
{
    public Task<List<Company>> GetCompaniesAsync();
    public Task<Company?> GetCompanyByIdAsync(int id);
    public Task<bool> AddCompanyAsync(Company company);
    public Task<bool> UpdateCompanyAsync(Company company);
    public Task<bool> DeleteCompanyAsync(int id);
}


