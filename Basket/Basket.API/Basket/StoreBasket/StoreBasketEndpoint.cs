
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCard ShoppingCard);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (ISender sender, StoreBasketCommand request) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{response.UserName}", response);
            })
              .WithName("CreateProduct")
              .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Create Product")
              .WithDescription("Create Product");
        }
    }
}
