using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class CompaniService : ICompanyService
{
    private readonly DataContext context = new();
    public async Task<bool> AddCompanyAsync(Company company)
    {
        using var connection = context.GetConnection();
        await connection.OpenAsync();

        var checkId = "select * from companies where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new {company.Id});
        if(exists != null)
        {
            System.Console.WriteLine("etot uje est");
            return false;
        }
    
        var sql = @"insert into companies(name, address, phone, email, created_at, updated_at)
                    values (@Name, @Address, @Phone, @Email, @CreatedAt, @UpdatedAt)";
        await connection.ExecuteAsync(sql , company);
        return true;
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        using var connection = context.GetConnection();
        await connection.OpenAsync();

        var checkId = "select * from companies where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new {Id = id});
        if(exists == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return false;
        }
    
        var sql = "delete from companies where id = @id";
        await connection.ExecuteAsync(sql , new {Id = id});
        return true;
    }

    public async Task<List<Company>> GetCompaniesAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = @"Select * from companies";

        var res = await connection.QueryAsync<Company>(sql);
        return res.ToList();
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = @"Select * from companies where id = @id";
        var company = await connection.QueryFirstOrDefaultAsync<Company>(sql , new{Id = id});

        if(company == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return null;
        }

        return company;
    }

    public async Task<bool> UpdateCompanyAsync(Company company)
    {
         using var connection = context.GetConnection();
        await connection.OpenAsync();

        var checkId = "select * from companies where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new {Id = company.Id});
        if(exists == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return false;
        }

        var sql = @"update companies
                    set name = @Name,
                    address = @Address,
                    phone = @Phone,
                    email = @Email,
                    updated_at = @UpdatedAt
                    where id = @Id";

        await connection.ExecuteAsync(sql, company);
        Console.WriteLine("Company successfully updated");
        return true;
    }

}
