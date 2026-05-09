using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class OrderService : IOrderService
{
    private readonly DataContext context = new();
    public async Task<bool> AddOrderAsync(Order order)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = @"insert into orders(company_id, order_date, status, total_amount, created_at, updated_at)
                    values(@CompanyId, @OrderDate, @Status, @TotalAmount, @CreatedAt, @UpdatedAt)";

        await connection.ExecuteAsync(sql, order);
        Console.WriteLine("Order successfully added");
        return true;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
         using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from orders where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{id = @id});
        if(exists == null)
        {
            System.Console.WriteLine("etot id netu");
            return false;
        }

        var sql = "delete from orders where id =@id";
        await connection.ExecuteAsync(sql, new{id});
        return true;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
          using var connection = context.GetConnection();
        connection.Open();

        var sql = "select * from orders where id = @Id";
        var order =await connection.QueryFirstOrDefaultAsync(sql , new{Id = @id});
        if(order == null)
        {
            System.Console.WriteLine("holi");
            return null;
        }
        return order;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = "select * from orders";
        var res = await connection.QueryAsync<Order>(sql);
        return res.ToList();
    }

    public async Task<bool> UpdateOrderAsync(Order order)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from orders where id = @Id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{Id = order.Id});
        if(exists == null)
        {
            System.Console.WriteLine("etot id netu");
            return false;
        }


        var sql = @"update orders
                    set company_id = @CompanyId,
                    order_date = @OrderDate,
                    status = @Status,
                    total_amount = @TotalAmount,
                    updated_at = @UpdatedAt
                    where id = @Id";

        await connection.ExecuteAsync(sql, order);
        Console.WriteLine("Order successfully updated");
        return true;
    }

}
