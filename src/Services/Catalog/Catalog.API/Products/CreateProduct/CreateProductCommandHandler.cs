﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand<CreateProductResult>(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand<CreateProductResult>, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand<CreateProductResult> command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}