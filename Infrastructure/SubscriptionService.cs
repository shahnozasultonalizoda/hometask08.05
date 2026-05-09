using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class SubscriptionService : ISubscriptionService
{
    private readonly DataContext context = new ();
    public async Task<bool> AddSubscriptionAsync(Subscription subscription)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "select * from subscriptions where id = @id";
        var exists =await connection.QueryFirstOrDefaultAsync(checkId , new{id = subscription.Id});
        if(exists != null)
        {
            System.Console.WriteLine("etot uje est");
            return false;
        }
    
        var sql = @"insert into subscriptions(CompanyId, IsActive, CreatedAt, UpdatedAt)
                    values (@MenuDate, @IsActive, @CreatedAt, @UpdatedAt)";
        await connection.ExecuteAsync(sql , menu);
        return true;


    }

    public Task<bool> DeleteSubscriptionAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Subscription?> GetSubscriptionByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Subscription>> GetSubscriptionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateSubscriptionAsync(Subscription subscription)
    {
        throw new NotImplementedException();
    }

}
