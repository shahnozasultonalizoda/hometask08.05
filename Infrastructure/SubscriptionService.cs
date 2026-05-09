using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure;

public class SubscriptionService : ISubscriptionService
{
    private readonly DataContext context = new();

    public async Task<bool> AddSubscriptionAsync(Subscription subscription)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = @"INSERT INTO subscriptions(companyid, plantype, mealsperday, price, startdate, enddate, isactive, created_at, updated_at)
                    VALUES(@CompanyId, @PlanType, @MealsPerDay, @Price, @StartDate, @EndDate, @IsActive, @CreatedAt, @UpdatedAt)";
        await connection.ExecuteAsync(sql, subscription);
        return true;
    }

    public async Task<bool> DeleteSubscriptionAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "SELECT * FROM subscriptions WHERE id = @Id";
        var exists = await connection.QueryFirstOrDefaultAsync(checkId, new { Id = id });
        if (exists == null)
        {
            Console.WriteLine("netu");
            return false;
        }

        var sql = "DELETE FROM subscriptions WHERE id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
        return true;
    }

    public async Task<Subscription?> GetSubscriptionByIdAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = "SELECT * FROM subscriptions WHERE id = @Id";
        var subscription = await connection.QueryFirstOrDefaultAsync<Subscription>(sql, new { Id = id });
        if (subscription == null)
        {
            Console.WriteLine("netu");
            return null;
        }

        return subscription;
    }

    public async Task<List<Subscription>> GetSubscriptionsAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        var sql = "SELECT * FROM subscriptions";
        var res = await connection.QueryAsync<Subscription>(sql);
        return res.ToList();
    }

    public async Task<bool> UpdateSubscriptionAsync(Subscription subscription)
    {
        using var connection = context.GetConnection();
        connection.Open();

        var checkId = "SELECT * FROM subscriptions WHERE id = @Id";
        var exists = await connection.QueryFirstOrDefaultAsync(checkId, new { Id = subscription.Id });
        if (exists == null)
        {
            Console.WriteLine("netu");
            return false;
        }

        var sql = @"UPDATE subscriptions SET
                    companyid = @CompanyId,
                    plantype = @PlanType,
                    mealsperday = @MealsPerDay,
                    price = @Price,
                    startdate = @StartDate,
                    enddate = @EndDate,
                    isactive = @IsActive,
                    updated_at = @UpdatedAt
                    WHERE id = @Id";

        await connection.ExecuteAsync(sql, subscription);
        return true;
    }
}