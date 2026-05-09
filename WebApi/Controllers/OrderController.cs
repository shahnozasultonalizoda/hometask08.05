using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/order")]
public class OrderController 
{
    private readonly IOrderService orderService = new OrderService();

    [HttpPost]
    public async Task<bool> AddOrderAsync(Order order)
    {
        return await orderService.AddOrderAsync(order);
    }

    [HttpDelete ("{id:int}")]

    public async Task<bool> DeleteOrderAsync(int id)
    {
        return await orderService.DeleteOrderAsync(id);
    }


    [HttpGet ("{id:int}")]

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await orderService.GetOrderByIdAsync(id);
    }

    [HttpGet]

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await orderService.GetOrdersAsync();
    }


    [HttpPut ("id:int")]

    public async Task<bool> UpdateOrderAsync(int id , Order order)
    {
        id = order.Id;
        return await orderService.UpdateOrderAsync(order);
    }

}
