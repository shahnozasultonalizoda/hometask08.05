using Domain.Models;

namespace Infrastructure;

public interface IMenuItemsService
{
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<bool> AddMenuItemAsync(MenuItem menuItem);
    Task<bool> UpdateMenuItemAsync(MenuItem menuItem);
    Task<bool> DeleteMenuItemAsync(int id);
    Task<MenuItem?> GetMenuItemByIdAsync(int id);
}
