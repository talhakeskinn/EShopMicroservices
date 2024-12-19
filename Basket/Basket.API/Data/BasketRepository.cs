namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCard>(userName);
            await session.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingCard> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCard>(userName, cancellationToken);
            return basket is null ? throw new FileNotFoundException() : basket;
        }

        public async Task<ShoppingCard> StoreBasket(ShoppingCard basket, CancellationToken cancellationToken = default)
        {
            session.Store<ShoppingCard>(basket);
            await session.SaveChangesAsync();
            return basket;
        }
    }
}
