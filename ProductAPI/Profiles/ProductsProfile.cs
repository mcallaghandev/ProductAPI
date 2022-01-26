namespace ProductAPI.Profiles
{
    using AutoMapper;
    using ProductAPI.Models;
    using ProductAPI.Dtos;

    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();

            CreateMap<SqlProduct, ProductReadDto>();
            CreateMap<ProductCreateDto, SqlProduct>();
            CreateMap<ProductUpdateDto, SqlProduct>();
            CreateMap<SqlProduct, ProductUpdateDto>();
        }
    }
}
