using System.ComponentModel.Design;
using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class MenuService : IMenuService
{
    private readonly DataContext context = new();
    public async Task<bool> AddMenuAsync(Menu menu)
    {
        using var connection = context.GetConnection();
        await connection.OpenAsync();

        var checkId = "select * from menus where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{id = menu.Id});
        if(exists != null)
        {
            System.Console.WriteLine("etot uje est");
            return false;
        }
    
        var sql = @"insert into menus(MenuDate, IsActive, CreatedAt, UpdatedAt)
                    values (@MenuDate, @IsActive, @CreatedAt, @UpdatedAt)";
        await connection.ExecuteAsync(sql , menu);
        return true;
    }

    public async Task<bool> DeleteMenuAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from menus where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{id});
        if(exists == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return false;
        }

        var sql = "delete from menus where id = @id";
        await connection.ExecuteAsync(sql , new{id});
        return true;


    }

    public async Task<Menu?> GetMenuByIdAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = "select * from menus where id = @id";
        var manu =await connection.QueryFirstOrDefaultAsync<Menu>(sql , new {Id = @id});
        if(manu == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return null;
        }

        return manu;
        
    }

    public async Task<List<Menu>> GetMenusAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = "select * from menus ";
        var res =await connection.QueryAsync<Menu>(sql);
        return res.ToList();
    }

    public async Task<bool> UpdateMenuAsync(Menu menu)
    {
        using var connection = context.GetConnection();
        connection.Open();


        var checkId = "select * from menus where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = menu.Id});
        if(exists == null)
        {
            System.Console.WriteLine("ne sushistvuet");
            return false;
        }

        var sql = @"update menus set
                     MenuDate = @MenuDate,
                     IsActive = @IsActive,
                     CreatedAt = @CreatedAt, 
                    UpdatedAt = @UpdatedAt
                    where id = @id ";
         await connection.ExecuteAsync(sql , menu);
         return true;

    }

}
