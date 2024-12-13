﻿namespace Catalog.API.Products.GetProducts
{
    public class GetProductsEndpoint : CarterModule
    {
        public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10); 
        public record GetProductsResponse(IEnumerable<Product> Products);

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/getproducts", async (ISender sender,[AsParameters]GetProductsRequest request) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var response = await sender.Send(query);
                var result = response.Adapt<GetProductsResponse>();
                return Results.Ok(result);
            })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
        }
    }
}
