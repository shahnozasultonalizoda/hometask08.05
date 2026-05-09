using Domain.Models;
using Infrastructure;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/company")]
public class CompanyController 
{
    private readonly ICompanyService companyService = new CompaniService();

    [HttpGet]
    public async  Task<List<Company>> GetCompaniesAsync()
    {
        return await companyService.GetCompaniesAsync();
    }
    [HttpGet ("{id:int}")]
    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        return await companyService.GetCompanyByIdAsync(id);
    }

    [HttpPost]
    public async Task<bool> AddCompanyAsync(Company company)
    {
        return await companyService.AddCompanyAsync(company);
    }

    [HttpPut ("{id:int}")]
    public async Task<bool> UpdateCompanyAsync(int id , Company company)
    {
        company.Id = id;
        return await companyService.UpdateCompanyAsync(company);
    }

    [HttpDelete ("{id:int}")]
    public async Task<bool> DeleteCompanyAsync(int id)
    {
        return await companyService.DeleteCompanyAsync(id);
    }


    [HttpGet ("with-order-count")]
    public async Task<List<GetCompaniesWithOrderCountDto>> GetCompaniesWithOrderCountAsync()
    {
        return await companyService.GetCompaniesWithOrderCountAsync();
    }
}
