using Domain.Models;

namespace Infrastructure;

public interface IMenuService
{
    public Task<List<Menu>> GetMenusAsync();
    public Task<Menu?> GetMenuByIdAsync(int id);
    public Task<bool> AddMenuAsync(Menu menu);
    public Task<bool> UpdateMenuAsync(Menu menu);
    public Task<bool> DeleteMenuAsync(int id);
}
