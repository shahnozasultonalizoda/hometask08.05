using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController 
{
    private readonly IMenuService menuService = new MenuService();

    [HttpPost]
    public async Task<bool> AddMenuAsync(Menu menu)
    {
        return await menuService.AddMenuAsync(menu);
    }

    [HttpDelete ("{id:int}")]
    public async Task<bool> DeleteMenuAsync(int id)
    {
        return await menuService.DeleteMenuAsync(id);
    }

    [HttpGet ("{id:int}")]
    public async Task<Menu?> GetMenuByIdAsync(int id)
    {
        return await menuService.GetMenuByIdAsync(id);
    }

    [HttpGet]
    public async Task<List<Menu>> GetMenusAsync()
    {
        return await menuService.GetMenusAsync();
    }

    [HttpPut]
    public async Task<bool> UpdateMenuAsync(Menu menu)
    {
        return await menuService.UpdateMenuAsync(menu);
    }

}
