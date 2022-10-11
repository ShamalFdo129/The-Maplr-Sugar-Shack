using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SugarShack.Application.Common.Dtos;
using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Interfaces;



namespace SugarShack.Application.Product.Queries.GetAllProducts
{
    public record GetAllProducts : IRequest<List<ProductDto>>;

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProducts, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<ProductDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var result = _context.Products
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToList();

            if(result ==null || result.Count == 0)
            {
                throw new NotFoundException("Empty Product List");
            }

            return Task.FromResult(result);

        }
    }
}
