using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class MenuItemsService : IMenuItemsService
{
    private readonly DataContext context = new();
    public async Task<bool> AddMenuItemAsync(MenuItem menuItem)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from menuitems where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = menuItem.Id});
        if(exists != null)
        {
            System.Console.WriteLine("uje est");
            return false;
        }

         var sql = @"insert into menuitems(menu_id, name, description, price, category, created_at, updated_at)
                    values(@MenuId, @Name, @Description, @Price, @Category, @CreatedAt, @UpdatedAt)";

        await connection.ExecuteAsync(sql, menuItem);
        Console.WriteLine("Menu item successfully added");
        return true;
    }

    public async Task<bool> DeleteMenuItemAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from menuitems where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = id});
        if(exists == null)
        {
            System.Console.WriteLine("netu");
            return false;
        }

        var sql = "delete from menuiteams where id = @id";
        await connection.ExecuteAsync(sql , new{id});
        return true;
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from menuitems where id = @id";
        var menuitem =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = id});
        if(menuitem == null)
        {
            System.Console.WriteLine("nete");
            return null;
        }
        return menuitem;
        
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
         using var connection = context.GetConnection();
        connection.Open();

        var sql = "select *  from menuitems ";
        var res = await connection.QueryAsync<MenuItem>(sql);
        return res.ToList();
    }

    public async Task<bool> UpdateMenuItemAsync(MenuItem menuItem)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from menuitems where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = id});
        if(exists == null)
        {
            System.Console.WriteLine("netu");
            return false;
        }

        var sql = @"update menuitems set
                    MenuId = @MenuId,
                    Name = @Name,
                    Description = @Description,
                    Price = @Price,
                    Category = @Category,
                    CreatedAt = @CreatedAt,
                    UpdatedAt = @UpdatedAt
                    where id = @id";
        await connection.ExecuteAsync(sql , menuItem);
        return true;
    }

}
