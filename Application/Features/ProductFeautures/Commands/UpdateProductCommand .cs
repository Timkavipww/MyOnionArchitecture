

using Application.Interfaces;

namespace Application.Features.ProductFeautures.Commands;

public class UpdateProductCommand :IRequest<int>
{
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
    public int Id { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cts)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cts);

            if (product == null)
            {
                return default;
            }
            else
            {
                product.Name = request.Name;
                product.Barcode = request.Barcode;
                product.Description = request.Description;
                product.Rate = request.Rate;
                await _context.SaveChangesAsync(cts);
                return product.Id;
            }
        }
    }
}
