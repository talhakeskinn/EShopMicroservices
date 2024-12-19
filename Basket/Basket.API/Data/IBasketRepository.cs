namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCard> GetBasket(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCard> StoreBasket(ShoppingCard basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    }
}
