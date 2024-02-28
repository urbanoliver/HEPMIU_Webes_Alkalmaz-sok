namespace ArmyWebAppUI.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int weaponId, int qt);

        Task<int> RemoveItem(int weaponId);

        Task<ShoppingCart> GetCart(string userId);

        Task<ShoppingCart> GetUserCart();

        Task<int> GetCartItemCount(string userId = "");

        Task<bool> DoCheck();

    }
}