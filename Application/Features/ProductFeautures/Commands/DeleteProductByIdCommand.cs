
using Application.Interfaces;

namespace Application.Features.ProductFeautures.Commands;

public class DeleteProductByIdCommand : IRequest<int>
{
    public int Id { get; set; }

    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductByIdCommandHandler(IApplicationDbContext context) => _context = context;
        public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cts)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cts);

            if (product == null) return default;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cts);
            return product.Id;
        }
    }
}
