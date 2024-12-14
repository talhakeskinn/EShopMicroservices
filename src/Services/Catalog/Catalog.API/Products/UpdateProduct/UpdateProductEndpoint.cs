﻿
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, decimal Price);
    public record UpdateProductResponse(bool isSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapPut("/products" ,async (ISender sender, UpdateProductRequest request) =>
           {
               var command = request.Adapt<UpdateProductCommand>();
               var result = await sender.Send(command);
               var response = result.Adapt<UpdateProductResponse>();
               return Results.Ok(response);
           })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
