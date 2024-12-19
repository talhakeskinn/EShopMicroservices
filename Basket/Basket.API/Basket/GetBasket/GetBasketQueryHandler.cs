using Basket.API.Data;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCard ShoppingCard);


    public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasket.GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(request.UserName, cancellationToken);
            return new GetBasketResult(basket);
        }
    }
}
