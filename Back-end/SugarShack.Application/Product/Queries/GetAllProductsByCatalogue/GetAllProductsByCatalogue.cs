using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using SugarShack.Application.Common.Dtos;
using SugarShack.Application.Common.Interfaces;
using SugarShack.Domain.Enums;



namespace SugarShack.Application.Product.Queries.GetAllProductsByCatalogue
{
    public record GetAllProductsByCatalogue : IRequest<List<ProductDto>>
    {
        public Catalogue Type { get; set; }
    }

    public class GetAllProductsByCatalogueHandler : IRequestHandler<GetAllProductsByCatalogue, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsByCatalogueHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<ProductDto>> Handle(GetAllProductsByCatalogue request, CancellationToken cancellationToken)
        {
            var result = _context.Products
                .Where(x => x.Type == request.Type)
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToList();
            return Task.FromResult(result);
        }
    }
}
