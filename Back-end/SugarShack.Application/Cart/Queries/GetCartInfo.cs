using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SugarShack.Application.Cart.Queries.Dtos;
using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Queries
{
    public record GetCartInfo : IRequest<CartDto>;

    public class GetCartInfoHandler : IRequestHandler<GetCartInfo, CartDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCartInfoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CartDto> Handle(GetCartInfo request, CancellationToken cancellationToken)
        {
            
            var result = _mapper.Map<CartDto>(_context.Carts.Include(c => c.Items).ThenInclude(I => I.Product).FirstOrDefault());

            if (result == null || result.Items == null)
            {
                throw new NotFoundException("Empty Cart");
            }

            return Task.FromResult(result);

        }
    }

}
