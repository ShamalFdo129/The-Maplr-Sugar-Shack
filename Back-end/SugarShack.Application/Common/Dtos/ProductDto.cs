using AutoMapper;

using SugarShack.Application.Common.Mappings;
namespace SugarShack.Application.Common.Dtos
{
    public class ProductDto: IMapFrom<SugarShack.Domain.Entities.Product>
    {
        public int Id { get; set; }
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
