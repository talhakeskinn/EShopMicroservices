
using Basket.API.Data;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCard ShoppingCard) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);
    public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            var card = await repository.StoreBasket(command.ShoppingCard, cancellationToken);
            return new StoreBasketResult(card.UserName);
        }
    }
}
