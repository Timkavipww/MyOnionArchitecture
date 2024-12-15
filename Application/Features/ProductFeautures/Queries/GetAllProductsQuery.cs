
using Application.Interfaces;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Application.Features.ProductFeautures.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context) => _context = context;
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cts)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(cts);
            if (!products.Any())
                return null;

            return products.AsReadOnly();
        }
    }
}
