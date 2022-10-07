using AutoMapper;

using SugarShack.Application.Common.Mappings;
namespace SugarShack.Application.Product.Queries.GetAllProducts
{
    public class ProductDto: IMapFrom<SugarShack.Domain.Entities.Product>
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SugarShack.Domain.Entities.Product, ProductDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => (int)s.Type));
        }
    }
}
