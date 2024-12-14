using FluentValidation;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand<CreateProductResult>(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand<CreateProductResult>, CreateProductResult>
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
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand<CreateProductResult>>
    {

        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
