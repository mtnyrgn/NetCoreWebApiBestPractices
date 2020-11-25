﻿using System;
using AutoMapper;
using NetCoreBestPractices.API.DTO;
using NetCoreBestPractices.Core.Models;

namespace NetCoreBestPractices.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CateegoryWithProductDto>();
            CreateMap<CateegoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();

            CreateMap<ProductWithCategoryDto, Product>();

        }
    }
}
