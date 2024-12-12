using MediatR;

namespace Catalog.API.Models.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Catalog, string Description, string ImageFile, decimal Price) : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {

        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            //Business Logic
            throw new NotImplementedException();
        }
    }
}
