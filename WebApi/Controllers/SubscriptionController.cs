using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/subscription")]

public class SubscriptionController 
{
    private readonly ISubscriptionService subscriptionService = new SubscriptionService();


    [HttpPost]
    public async Task<bool> AddSubscriptionAsync(Subscription subscription)
    {
        return await subscriptionService.AddSubscriptionAsync(subscription);
    }

    [HttpDelete ("{id:int}")]
    public async Task<bool> DeleteSubscriptionAsync(int id)
    {
        return await subscriptionService.DeleteSubscriptionAsync(id);
    }

    [HttpGet ("{id:int}")]

    public async Task<Subscription?> GetSubscriptionByIdAsync(int id)
    {
        return await subscriptionService.GetSubscriptionByIdAsync(id);
    }

    [HttpGet]

    public async Task<List<Subscription>> GetSubscriptionsAsync()
    {
        return await subscriptionService.GetSubscriptionsAsync();
    }

    [HttpPut("{id:int}")]

    public async Task<bool> UpdateSubscriptionAsync(int id ,Subscription subscription)
    {
        id = subscription.Id;
        return await subscriptionService.UpdateSubscriptionAsync(subscription);
    }

}
