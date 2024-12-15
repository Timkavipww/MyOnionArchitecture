
using Application.Interfaces;

namespace Application.Features.ProductFeautures.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationDbContext _context;
        public GetProductByIdQueryHandler(IApplicationDbContext context) => _context = context;
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var proudct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);
            if (proudct != null) return null;

            return proudct;
        }
    }
}
