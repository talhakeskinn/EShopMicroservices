
using MediatR;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketResponse(bool isSuccess);
    public class DeleteBasketEnpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/Basket/{userName}", async (ISender sender, string userName) =>
            {
                var result = sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            })
              .WithName("DeleteProduct")
              .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Delete Product")
              .WithDescription("Delete Product");
        }
    }
}
