using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Product.Queries.GetAllProducts
{
    public record GetAllProductsQuery: IRequest<IList<ProductDto>>;

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotFoundException("Error");

            //return await _context.Products
            //    .AsNoTracking()
            //    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);
            
        }
    }


}
